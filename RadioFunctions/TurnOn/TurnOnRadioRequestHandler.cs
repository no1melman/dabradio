namespace DabRadio.RadioFunctions.TurnOn
{
    using System.Threading.Tasks;

    using MediatR;

    public class TurnOnRadioRequestHandler : IAsyncRequestHandler<TurnOnRadioRequest, bool>
    {
        private readonly IRadioCommandDispatcher commandDispatcher;

        public TurnOnRadioRequestHandler(
            IRadioCommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }
        
        public Task<bool> Handle(TurnOnRadioRequest message)
        {
            return Task.Run(() =>
            {
                var openPort = this.commandDispatcher.OpenPort(message.ComPort, message.UseHardMute);

                if (!openPort)
                {
                    this.commandDispatcher.ClosePort();
                }

                return openPort;
            });
        }
    }
}