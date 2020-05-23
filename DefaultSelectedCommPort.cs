namespace DabRadio
{
    public class DefaultSelectedCommPort : ISelectedCommPort
    {
        public DefaultSelectedCommPort(string commPort)
        {
            this.CommPort = commPort;
        }

        public string CommPort { get; }
    }
}