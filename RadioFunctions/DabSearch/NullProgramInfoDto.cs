namespace DabRadio.RadioFunctions.DabSearch
{
    public class NullProgramInfoDto : IProgramInfoDto
    {
        public NullProgramInfoDto()
        {
            this.ProgramName = string.Empty;
            this.DabIndex = 0;
            this.ServiceComponentId = 0;
            this.ServiceId = 0;
            this.EnsembleId = 0;
        }

        public uint DabIndex { get; }

        public byte ServiceComponentId { get; }

        public uint ServiceId { get; }

        public ushort EnsembleId { get; }

        public string ProgramName { get; }
    }
}