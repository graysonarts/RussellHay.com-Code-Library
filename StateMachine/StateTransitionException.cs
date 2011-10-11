using System;

namespace StateMachine
{
    public class StateTransitionException : Exception
    {
        public StateTransitionException(string error, string stateName, string transitionName) : base(String.Format("State {0}, Transition {1} {2}", stateName, transitionName, error))
        {

        }
    }
}