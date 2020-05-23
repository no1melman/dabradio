namespace DabRadio.RadioFunctions.Stream
{
    public interface IStreamCommandDispatcher
    {
        bool Stop();

        bool Play(int dabIndex);
    }
}