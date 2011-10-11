namespace StateMachine
{
    internal class TransitionAlreadyExistsException : StateTransitionException
    {
        public TransitionAlreadyExistsException(string stateName, string transitionName) : base("already exists", stateName, transitionName) 
        {
        }
    }
}