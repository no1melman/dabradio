namespace DabRadio.RadioFunctions.TurnOn
{
    using MediatR;

    public class TurnOnRadioRequest : IAsyncRequest<bool>
    {
        public TurnOnRadioRequest(
            string comPort,
            bool useHardMute)
        {
            this.ComPort = comPort;
            this.UseHardMute = useHardMute;
        }

        public string ComPort { get; private set; }

        public bool UseHardMute { get; private set; }
    }
}