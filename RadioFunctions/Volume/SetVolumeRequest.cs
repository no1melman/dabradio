namespace DabRadio.RadioFunctions.Volume
{
    using MediatR;

    public class SetVolumeRequest : IAsyncRequest<bool>
    {
        public SetVolumeRequest(sbyte volume)
        {
            this.Volume = volume;
        }

        public sbyte Volume { get; }
    }
}