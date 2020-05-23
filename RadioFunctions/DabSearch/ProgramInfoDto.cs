namespace DabRadio.RadioFunctions.DabSearch
{
    public class ProgramInfoDto : IProgramInfoDto
    {
        public ProgramInfoDto(uint dabIndex, byte serviceComponentId, uint serviceId, ushort ensembleId, string programName)
        {
            this.DabIndex = dabIndex;
            this.ServiceComponentId = serviceComponentId;
            this.ServiceId = serviceId;
            this.EnsembleId = ensembleId;
            this.ProgramName = programName;
        }

        public uint DabIndex { get; }

        public byte ServiceComponentId { get; }

        public uint ServiceId { get; }

        public ushort EnsembleId { get; }

        public string ProgramName { get; }

        public override string ToString()
        {
            return this.ProgramName;
        }
    }
}