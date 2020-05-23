namespace DabRadio.RadioFunctions.Stream.Stop
{
    using System.Threading.Tasks;

    using MediatR;

    public class StopStreamRequestHandler : IAsyncRequestHandler<StopStreamRequest, bool>
    {
        private readonly IStreamCommandDispatcher streamCommandDispatcher;

        public StopStreamRequestHandler(IStreamCommandDispatcher streamCommandDispatcher)
        {
            this.streamCommandDispatcher = streamCommandDispatcher;
        }

        public Task<bool> Handle(StopStreamRequest message)
        {
            return Task.Run(() => this.streamCommandDispatcher.Stop());
        }
    }
}