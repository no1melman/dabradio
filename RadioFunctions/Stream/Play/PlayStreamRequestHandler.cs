namespace DabRadio.RadioFunctions.Stream.Play
{
    using System.Threading.Tasks;

    using MediatR;

    public class PlayStreamRequestHandler : IAsyncRequestHandler<PlayStreamRequest, bool>
    {
        private readonly IStreamCommandDispatcher streamCommandDispatcher;

        public PlayStreamRequestHandler(
            IStreamCommandDispatcher streamCommandDispatcher)
        {
            this.streamCommandDispatcher = streamCommandDispatcher;
        }

        public Task<bool> Handle(PlayStreamRequest message)
        {
            return Task.Run(() => this.streamCommandDispatcher.Play(message.DabIndex));
        }
    }
}