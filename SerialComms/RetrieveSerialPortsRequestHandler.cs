namespace DabRadio.SerialComms
{
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Threading.Tasks;

    using MediatR;

    public class RetrieveSerialPortsRequestHandler : IAsyncRequestHandler<RetrieveSerialPortsRequest, IEnumerable<SerialPortDto>>
    {
        public Task<IEnumerable<SerialPortDto>> Handle(RetrieveSerialPortsRequest message)
        {
            return Task.Run(() =>
                    {
                        var ports = SerialPort.GetPortNames();

                        var serialPortDtos = new List<SerialPortDto>();

                        foreach (var port in ports)
                        {
                            using (var serialPort = new SerialPort(port))
                            {
                                var serialPortDto = new SerialPortDto(serialPort.BaudRate, serialPort.PortName);
                                serialPortDtos.Add(serialPortDto);
                            }
                        }

                        return serialPortDtos.AsEnumerable();
                    });
        }
    }
}