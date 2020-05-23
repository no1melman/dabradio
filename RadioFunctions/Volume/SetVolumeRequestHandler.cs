namespace DabRadio.RadioFunctions.Volume
{
    using System.Threading.Tasks;

    using MediatR;

    public class SetVolumeRequestHandler : IAsyncRequestHandler<SetVolumeRequest, bool>
    {
        private readonly IRadioCommandDispatcher commandDispatcher;

        public SetVolumeRequestHandler(IRadioCommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public Task<bool> Handle(SetVolumeRequest message)
        {
            return Task.Run(() => this.commandDispatcher.SetRadioVolume(message.Volume));
        }
    }
}