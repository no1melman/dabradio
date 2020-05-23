namespace DabRadio
{
    public class OnDabFunctionOptions : IOnDabFunctionOptions
    {
        public OnDabFunctionOptions(
            string comPort, 
            bool useHardMute)
        {
            ComPort = comPort;
            UseHardMute = useHardMute;
        }

        public string ComPort { get; private set; }
        public bool UseHardMute { get; private set; }
    }
}