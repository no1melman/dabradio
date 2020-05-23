namespace DabRadio
{
    using RadioFunctions.DabSearch;

    public static class ProgramInfoDtoExtensions
    {
        public static IProgramInfoDto Clone(this IProgramInfoDto programInfo, uint dabIndex = uint.MaxValue, byte serviceComponentId = byte.MaxValue, uint serviceId = uint.MaxValue, ushort ensembleId = ushort.MaxValue, string programName = null)
        {
            return new ProgramInfoDto( 
                dabIndex == uint.MaxValue ? programInfo.DabIndex : dabIndex,
                serviceComponentId == byte.MaxValue ? programInfo.ServiceComponentId : serviceComponentId,
                serviceId == uint.MaxValue ? programInfo.ServiceId : serviceId,
                ensembleId == ushort.MaxValue ? programInfo.EnsembleId : ensembleId,
                programName ?? programInfo.ProgramName);
        }
    }
}