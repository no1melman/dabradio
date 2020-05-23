namespace DabRadio.RadioFunctions.TurnOff
{
    using System.Threading.Tasks;
    
    using MediatR;

    public class TurnOffRequestHandler : IAsyncRequestHandler<TurnOffRequest, bool>
    {
        private readonly IRadioCommandDispatcher radioCommandDispatcher;

        public TurnOffRequestHandler(
            IRadioCommandDispatcher radioCommandDispatcher)
        {
            this.radioCommandDispatcher = radioCommandDispatcher;
        }

        public Task<bool> Handle(TurnOffRequest message)
        {
            return Task.Run(() => this.radioCommandDispatcher.ClosePort());
        }
    }
}