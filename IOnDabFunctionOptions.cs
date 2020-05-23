namespace DabRadio
{
    public interface IOnDabFunctionOptions : IDabOptions
    {
        string ComPort { get; }

        bool UseHardMute { get; }
    }
}