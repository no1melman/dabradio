namespace DabRadio.RadioFunctions.DabSearch
{
    public interface IProgramInfoDto
    {
        uint DabIndex { get; }

        byte ServiceComponentId { get; }

        uint ServiceId { get; }

        ushort EnsembleId { get; }

        string ProgramName { get; }
    }
}