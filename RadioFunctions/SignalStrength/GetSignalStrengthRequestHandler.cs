namespace DabRadio.RadioFunctions.SignalStrength
{
    using System.Threading.Tasks;

    using MediatR;

    public class GetSignalStrengthRequestHandler : IAsyncRequestHandler<GetSignalStrengthRequest, sbyte>
    {
        private readonly IRadioCommandDispatcher commandDispatcher;

        public GetSignalStrengthRequestHandler(
            IRadioCommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public Task<sbyte> Handle(GetSignalStrengthRequest message)
        {
            return Task.Run(() => this.commandDispatcher.SignalStrength());
        }
    }
}
