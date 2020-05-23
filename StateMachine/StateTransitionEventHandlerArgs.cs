namespace DabRadio.StateMachine
{
    public class StateTransitionEventHandlerArgs
    {
        public StateTransitionEventHandlerArgs(RadioState prevState, RadioState nextState)
        {
            this.PrevState = prevState;
            this.NextState = nextState;
        }

        public RadioState PrevState { get; }

        public RadioState NextState { get; }
    }
}