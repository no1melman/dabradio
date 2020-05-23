namespace DabRadio.RadioFunctions.DabSearch
{
    using System.Runtime.InteropServices;

    public class DabCommandDispatcher : IDabCommandDispatcher
    {
        public int GetAllPrograms()
        {
            return GetTotalProgram();
        }

        public string ProgramName(uint dabIndex)
        {
            var name = new string(' ', 400);

            if (GetProgramName(0, dabIndex, 1, name))
            {
                return name.Trim();
            }

            return string.Empty;
        }

        public IProgramInfoDto ProgramInfo(uint dabIndex)
        {
            byte serviceComponentId = byte.MinValue;
            uint serviceId = 0;
            ushort ensembleId = 0;

            if (GetProgramInfo(dabIndex, ref serviceComponentId, ref serviceId, ref ensembleId))
            {
                return new ProgramInfoDto(dabIndex, serviceComponentId, serviceId, ensembleId, string.Empty);
            }

            return new NullProgramInfoDto();
        }

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern int GetTotalProgram();

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll", CharSet = CharSet.Unicode)]
        private static extern bool GetProgramName(sbyte mode, uint dabIndex, sbyte namemode, string programName);

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll", CharSet = CharSet.Unicode)]
        private static extern bool GetProgramInfo(uint dabIndex, ref byte ServiceComponentID, ref uint ServiceID, ref ushort EnsembleID);
    }
}