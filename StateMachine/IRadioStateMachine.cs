namespace DabRadio.StateMachine
{
    public interface IRadioStateMachine
    {
        event StateTransitionEventHandler StateTransition;

        bool CanMoveTo(RadioState goToRadioState);

        void MoveTo(RadioState radioState);

        RadioState CurrentState { get; }

    }

    public delegate void StateTransitionEventHandler(object sender, StateTransitionEventHandlerArgs args);
}