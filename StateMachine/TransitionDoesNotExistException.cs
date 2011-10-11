namespace StateMachine
{
    public class TransitionDoesNotExistException : StateTransitionException
    {
        public TransitionDoesNotExistException(string stateName, string transitionName) : base("does not exist", stateName, transitionName)
        {

        }
    }
}