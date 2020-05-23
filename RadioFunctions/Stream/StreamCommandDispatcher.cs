namespace DabRadio.RadioFunctions.Stream
{
    using System;
    using System.Runtime.InteropServices;

    public class StreamCommandDispatcher : IStreamCommandDispatcher
    {
        private const int DabMode = 0;

        public bool Stop()
        {
            return StopStream();
        }

        public bool Play(int dabIndex)
        {
            return PlayStream(DabMode, dabIndex);
        }

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern bool StopStream();

        [DllImport("C:\\Users\\DevSup\\Documents\\Visual Studio 2015\\keystonecomm.dll")]
        private static extern bool PlayStream(sbyte mode, Int32 channel);
    }
}