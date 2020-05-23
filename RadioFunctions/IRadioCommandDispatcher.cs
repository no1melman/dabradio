namespace DabRadio.RadioFunctions
{
    public interface IRadioCommandDispatcher
    {
        bool OpenPort(string comPort, bool useHardMute);

        bool ClosePort();

        bool SetRadioVolume(sbyte volume);

        sbyte SignalStrength();

        string ProgramText();
    }
}