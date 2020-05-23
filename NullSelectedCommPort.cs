namespace DabRadio
{
    public class NullSelectedCommPort : ISelectedCommPort
    {
        public NullSelectedCommPort()
        {
            this.CommPort = string.Empty;
        }

        public string CommPort { get; }
    }
}