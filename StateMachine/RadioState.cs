namespace DabRadio.StateMachine
{
    public enum RadioState
    {
        Initial,
        Stopped,
        Playing,
        GettingRadioStations,
        GettingRadioDevices,
        DeviceSelected,
        DeviceOn,
        DeviceOff,

        RadioStationSelected
    }
}