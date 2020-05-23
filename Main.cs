namespace DabRadio
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using DabRadio.RadioFunctions.ProgramInfo;
    using DabRadio.RadioFunctions.SignalStrength;
    using DabRadio.RadioFunctions.Stream.Play;
    using DabRadio.RadioFunctions.Volume;

    using MediatR;

    using RadioFunctions.DabSearch;
    using RadioFunctions.TurnOff;
    using RadioFunctions.TurnOn;

    using SerialComms;

    using StateMachine;

    public partial class Main : Form
    {
        private readonly IMediator mediator;

        private readonly IRadioStateMachine stateMachine;

        private ISelectedCommPort selectedCommPort;

        private int volume = 7;

        private CancellationTokenSource signal;

        public Main(IMediator mediator, IRadioStateMachine stateMachine)
        {
            this.mediator = mediator;
            this.stateMachine = stateMachine;
            this.stateMachine.StateTransition += this.StateMachineOnStateTransition;

            this.selectedCommPort = new NullSelectedCommPort();

            this.InitializeComponent();
        }

        private async void StateMachineOnStateTransition(object sender, StateTransitionEventHandlerArgs args)
        {
            this.HandleGettingRadioDevicesTransition(args.NextState);
            this.HandleDeviceOffTransition(args.NextState);
            this.HandleDeviceOnTransition(args.NextState);
            this.HandleDeviceSelectedTransition(args.NextState);
            await this.HandlePlayingTransition(args.NextState);
        }

        private void DisplaySerialPorts(IEnumerable<SerialPortDto> serialPortDtos)
        {
            foreach (var serialPortDto in serialPortDtos)
            {
                this.SerialCommsListBox.Items.Add(serialPortDto.ToString());
            }
        }

        private async void RefreshSerialCommsButton_Click(object sender, EventArgs e)
        {
            var canMoveTo = this.stateMachine.CanMoveTo(RadioState.GettingRadioDevices);

            if (!canMoveTo)
            {
                return;
            }

            this.SerialCommsListBox.Items.Clear();

            var serialPortDtos = await this.mediator.SendAsync(new RetrieveSerialPortsRequest());

            this.DisplaySerialPorts(serialPortDtos);

            this.stateMachine.MoveTo(RadioState.GettingRadioDevices);
        }

        private void SerialCommsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var canMoveTo = this.stateMachine.CanMoveTo(RadioState.DeviceSelected);

            if (!canMoveTo)
            {
                return;
            }

            var commPort = this.SerialCommsListBox.SelectedItem;

            this.selectedCommPort = new DefaultSelectedCommPort((string)commPort);

            this.stateMachine.MoveTo(RadioState.DeviceSelected);
        }

        private async void OnOffButton_Click(object sender, EventArgs e)
        {
            var canMoveToDeviceOn = this.stateMachine.CanMoveTo(RadioState.DeviceOn);

            if (canMoveToDeviceOn)
            {
                await this.TurnOnDevice();

                return;
            }

            var canMoveToDeviceOff = this.stateMachine.CanMoveTo(RadioState.DeviceOff);

            if (!canMoveToDeviceOff)
            {
                return;
            }

            await this.TurnOffDevice();

            return;
        }

        private async void ProgramListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var b = this.ProgramListBox.SelectedItem as ProgramInfoDto;

            if (b == null)
            {
                throw new NullReferenceException("Program list box contains inccorect object");
            }

            var canMoveTo = this.stateMachine.CanMoveTo(RadioState.Playing);

            if (!canMoveTo)
            {
                return;   
            }

            // Need tune the radio here
            var playResult = await this.mediator.SendAsync(new PlayStreamRequest((int)b.DabIndex));

            if (playResult)
            {
                this.stateMachine.MoveTo(RadioState.Playing);
            }
        }

        private async void VolumeUpButton_Click(object sender, EventArgs e)
        {
            this.volume++;

            await this.SetVolume();
        }

        private async void VolumeDownButton_Click(object sender, EventArgs e)
        {
            this.volume--;

            await this.SetVolume();
        }

        private async Task GetPrograms()
        {
            var canMoveTo = this.stateMachine.CanMoveTo(RadioState.GettingRadioStations);

            if (!canMoveTo)
            {
                return;
            }

            var programInfoDtos = await this.mediator.SendAsync(new GetDabProgramsRequest());

            if (!programInfoDtos.Any())
            {
                return;
            }

            this.ProgramListBox.Items.Clear();

            foreach (var programInfoDto in programInfoDtos)
            {
                this.ProgramListBox.Items.Add(programInfoDto);
            }

            this.stateMachine.MoveTo(RadioState.GettingRadioStations);
        }

        private async Task TurnOffDevice()
        {
            var turnOffResult = await this.mediator.SendAsync(new TurnOffRequest());

            if (turnOffResult)
            {
                this.stateMachine.MoveTo(RadioState.DeviceOff);
            }
        }

        private async Task TurnOnDevice()
        {
            var turnOnResult =
                await this.mediator.SendAsync(
                    new TurnOnRadioRequest(@"\\.\" + this.selectedCommPort.CommPort.Substring(0, 5).Trim(), true));

            if (turnOnResult)
            {
                this.stateMachine.MoveTo(RadioState.DeviceOn);

                await this.SetVolume();

                await this.GetPrograms();
            }
        }

        private void HandleGettingRadioDevicesTransition(RadioState nextState)
        {
            if (nextState != RadioState.GettingRadioDevices)
            {
                return;
            }
        }

        private void HandleDeviceOffTransition(RadioState nextState)
        {
            if (nextState != RadioState.DeviceOff)
            {
                return;
            }

            this.OnOffButton.BackColor = Color.GreenYellow;
            this.OnOffButton.Text = "On";

            this.ProgramListBox.Items.Clear();
        }

        private void HandleDeviceOnTransition(RadioState nextState)
        {
            if (nextState != RadioState.DeviceOn)
            {
                return;
            }
        
            this.OnOffButton.BackColor = Color.Red;
            this.OnOffButton.Text = "Off";
        }

        private void HandleDeviceSelectedTransition(RadioState nextState)
        {
            if (nextState != RadioState.DeviceSelected)
            {
                return;
            }

            this.OnOffButton.Enabled = true;
            this.OnOffButton.BackColor = Color.GreenYellow;
            this.OnOffButton.Text = "On";
        }

        private async Task HandlePlayingTransition(RadioState nextState)
        {
            if (nextState != RadioState.Playing)
            {
                return;
            }

            await this.StartSignalMeasure();
        }

        private async Task SetVolume()
        {
            await this.mediator.SendAsync(new SetVolumeRequest((sbyte)this.volume));
        }

        private async Task StartSignalMeasure()
        {
            this.signal?.Cancel();

            await Task.Delay(400);

            this.signal = new CancellationTokenSource();

            // we want a long running thread
#pragma warning disable 4014
            Task.Run(async () =>
            {
                Debug.WriteLine("Starting signal measure");

                while (!this.signal.IsCancellationRequested)
                {
                    await this.GetSignalStrength();

                    await this.GetProgramInfo();

                    this.signal.Token.WaitHandle.WaitOne(300);
                }

                Debug.WriteLine("Exiting signal measure");
            });
#pragma warning restore 4014
        }

        private async Task GetSignalStrength()
        {
            var signalStrength = await this.mediator.SendAsync(new GetSignalStrengthRequest());

            if (this.SignalStrengthLabel.InvokeRequired)
            {
                this.SignalStrengthLabel.Invoke(new Action(() => { this.SignalStrengthLabel.Text = signalStrength + " %"; }));
            }
            else
            {
                this.SignalStrengthLabel.Text = signalStrength + " %";
            }
        }

        private async Task GetProgramInfo()
        {
            var programText = await this.mediator.SendAsync(new GetProgramTextRequest());

            if (this.ProgramTextLabel.InvokeRequired)
            {
                this.ProgramTextLabel.Invoke(new Action(() => { this.ProgramTextLabel.Text = programText; }));
            }
            else
            {
                this.ProgramTextLabel.Text = programText;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.signal.Cancel();
        }
    }
}