namespace DabRadio
{
    public interface IDabFunctionStrategy<in TDabOptions> 
        where TDabOptions : IDabOptions
    {
        bool CanHandle(string functionName);

        void Run(TDabOptions options);
    }
}