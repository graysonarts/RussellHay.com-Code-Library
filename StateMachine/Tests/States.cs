namespace StateMachine.Tests
{
    internal class BaseState :IState<Transitions>
    {
        public void Run(IStateMachine<Transitions> machine)
        {
        }
    }

    internal class FirstState : BaseState { }
    internal class SecondState : BaseState { }
    internal class ThirdState : BaseState { }
    internal class FinalState : BaseState { }
}