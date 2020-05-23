namespace DabRadio.SerialComms
{
    using System.Collections.Generic;

    using MediatR;

    public class RetrieveSerialPortsRequest : IAsyncRequest<IEnumerable<SerialPortDto>>
    {
    }
}