namespace DabRadio.SerialComms
{
    public class SerialPortDto
    {
        public SerialPortDto(int baudRate, string portName)
        {
            this.BaudRate = baudRate;
            this.PortName = portName;
        }

        public int BaudRate { get; }

        public string PortName { get; }

        public override string ToString()
        {
            return $"{this.PortName} ({this.BaudRate})";
        }
    }
}