namespace DabRadio.StateMachine
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public class RadioStateMachine : IRadioStateMachine
    {
        private readonly Dictionary<RadioState, IEnumerable<RadioState>> stateMovementDictionary = new Dictionary<RadioState, IEnumerable<RadioState>>
        {
            [RadioState.Initial] = new List<RadioState> { RadioState.GettingRadioDevices },
            [RadioState.GettingRadioDevices] = new List<RadioState> { RadioState.DeviceSelected },
            [RadioState.DeviceSelected] = new List<RadioState> { RadioState.DeviceOn, RadioState.DeviceSelected },
            [RadioState.DeviceOn] = new List<RadioState> { RadioState.DeviceOff, RadioState.GettingRadioStations },
            [RadioState.GettingRadioStations] = new List<RadioState> { RadioState.Playing, RadioState.DeviceOff },
            [RadioState.DeviceOff] = new List<RadioState> { RadioState.GettingRadioDevices, RadioState.DeviceSelected, RadioState.DeviceOn },
            [RadioState.Playing] = new List<RadioState> { RadioState.DeviceOff, RadioState.Stopped, RadioState.Playing }
        };

        private RadioState currentRadioState;

        public RadioStateMachine()
        {
            this.currentRadioState = RadioState.Initial; // always start off at the first state
        }

        public event StateTransitionEventHandler StateTransition;

        public RadioState CurrentState => this.currentRadioState;

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public bool CanMoveTo(RadioState goToRadioState)
        {
            var canMoveTo = this
                .stateMovementDictionary[this.currentRadioState]
                .Contains(goToRadioState);

            var canMoveText = canMoveTo ? "Yes" : "No";
            Debug.WriteLine($"From {this.currentRadioState}, To {goToRadioState}, {canMoveText}");

            return canMoveTo;
        }

        public void MoveTo(RadioState radioState)
        {
            var oldState = this.currentRadioState;

            this.currentRadioState = radioState;

            this.StateTransition?.Invoke(this, new StateTransitionEventHandlerArgs(oldState, this.currentRadioState));
        }
    }
}

