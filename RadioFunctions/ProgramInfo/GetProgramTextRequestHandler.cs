namespace DabRadio.RadioFunctions.ProgramInfo
{
    using System.Threading.Tasks;

    using MediatR;

    public class GetProgramTextRequestHandler : IAsyncRequestHandler<GetProgramTextRequest, string>
    {
        private readonly IRadioCommandDispatcher commandDispatcher;

        public GetProgramTextRequestHandler(
            IRadioCommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public Task<string> Handle(GetProgramTextRequest message)
        {
            return Task.Run(() => this.commandDispatcher.ProgramText());
        }
    }
}