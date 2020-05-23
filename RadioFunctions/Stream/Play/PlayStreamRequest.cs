namespace DabRadio.RadioFunctions.Stream.Play
{
    using MediatR;

    public class PlayStreamRequest : IAsyncRequest<bool>
    {
        public PlayStreamRequest(int dabIndex)
        {
            this.DabIndex = dabIndex;
        }

        public int DabIndex { get; }
    }
}