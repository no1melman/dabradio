namespace DabRadio.RadioFunctions
{
    using System.Runtime.InteropServices;

    public class RadioCommandDispatcher : IRadioCommandDispatcher
    {
        private int bitError = 0;

        private string programText = string.Empty;

        public bool OpenPort(string comPort, bool useHardMute)
        {
            var open = OpenRadioPort(comPort, useHardMute);

            return open && SetStereoMode(1);
        }

        public bool ClosePort()
        {
            return CloseRadioPort();
        }

        public bool SetRadioVolume(sbyte volume)
        {
            return SetVolume(volume);
        }

        public sbyte SignalStrength()
        {
            return GetSignalStrength(ref this.bitError);
        }

        public string ProgramText()
        {
            var programtext = new string(' ', 400);
            var result = GetProgramText(programtext);

            if (result == 0)
            {
                this.programText = programtext.Trim();
            }

            if (result == -1)
            {
                this.programText = string.Empty;
            }

            return this.programText;
        }

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern bool CloseRadioPort();

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll", CharSet = CharSet.Ansi)]
        private static extern bool OpenRadioPort(string port, bool usehardmute);

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern bool SetStereoMode(sbyte mode);

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern bool SetVolume(sbyte volume);

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern sbyte GetSignalStrength(ref int biterror);

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll", CharSet = CharSet.Unicode)]
        private static extern sbyte GetProgramText(string programtext);

    }
}