namespace DabRadio
{
    using System;
    using System.Runtime.InteropServices;

    public class TurnOnRadioDabFunction : IDabFunctionStrategy<IOnDabFunctionOptions>
    {
        [DllImport("C:\\Users\\DevSoft2\\Documents\\Visual Studio 2010\\Projects\\TestKeyStoneRadio\\TestKeyStoneRadio\\keystonecomm.dll")]
        private static extern bool OpenRadioPort(string port, bool usehardmute);

        [DllImport("C:\\Users\\DevSoft2\\Documents\\Visual Studio 2010\\Projects\\TestKeyStoneRadio\\TestKeyStoneRadio\\keystonecomm.dll")]
        private static extern bool SetStereoMode(sbyte mode);

        [DllImport("C:\\Users\\DevSoft2\\Documents\\Visual Studio 2010\\Projects\\TestKeyStoneRadio\\TestKeyStoneRadio\\keystonecomm.dll")]
        private static extern bool CloseRadioPort();

        public bool CanHandle(string functionName)
        {
            return string.Equals(functionName, "turn_on", StringComparison.OrdinalIgnoreCase);
        }

        public void Run(IOnDabFunctionOptions options)
        {
            var open = OpenRadioPort(options.ComPort, options.UseHardMute);

            if (open)
            {
                SetStereoMode(1);
            }
            else
            {
                CloseRadioPort();
            }
        }
    }
}