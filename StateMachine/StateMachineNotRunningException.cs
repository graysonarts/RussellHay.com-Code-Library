using System;

namespace StateMachine
{
    public class StateMachineNotRunningException : Exception
    {
        public StateMachineNotRunningException() : base("StateMachine is not running")
        {
        }
    }
}