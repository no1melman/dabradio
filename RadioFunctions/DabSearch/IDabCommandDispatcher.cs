namespace DabRadio.RadioFunctions.DabSearch
{
    public interface IDabCommandDispatcher
    {
        int GetAllPrograms();

        string ProgramName(uint dabIndex);

        IProgramInfoDto ProgramInfo(uint dabIndex);
    }
}