using System;
using NUnit.Framework;

namespace StateMachine.Tests
{
    [TestFixture]
    public class TestStateMachineBasic
    {
        private IStateMachine<Transitions> machine;

        [TestFixtureSetUp]
        public void CreateMachine()
        {
            machine = StateMachine.Create<Transitions, TransitionHandler>();
            machine.AddTransition(null, State<FirstState,Transitions>.Instance, Transitions.Start);
            machine.AddTransition(State<FirstState, Transitions>.Instance, State<SecondState, Transitions>.Instance, Transitions.Okay);
            machine.AddTransition(State<FirstState, Transitions>.Instance, State<ThirdState, Transitions>.Instance, Transitions.Error);
            machine.AddTransition(State<SecondState, Transitions>.Instance, null, Transitions.NormalExit);
            machine.AddTransition(State<ThirdState, Transitions>.Instance, State<FinalState, Transitions>.Instance, Transitions.CalculateErrorCode);
            machine.AddTransition(State<FinalState, Transitions>.Instance, null, Transitions.ExitWithErrorCode);
            
        }

        [TestCase]
        public void AddTransition()
        {
            machine.Start();
            Assert.AreEqual(typeof (FirstState).FullName, machine.State.GetType().FullName);
            Assert.IsTrue(machine.State is FirstState, "should be FirstState");
            machine.Transition(Transitions.Okay);
            Assert.IsTrue(machine.State is SecondState, "should be SecondState instead of {0}",
                          machine.State.GetType().FullName);
            machine.Transition(Transitions.NormalExit);
            Assert.IsNull(machine.State, "should be null instead of {0}", machine.State == null ? "null" : machine.State.GetType().FullName);
            Assert.IsFalse(machine.IsRunning, "state machine should not be running");
        }

        [TestCase(ExpectedExceptionName = "StateMachine.StateMachineNotRunningException")]
        public void TerminateStateMachineError()
        {
            AddTransition();
            machine.Transition(Transitions.NormalExit);
        }

        [TestCase(ExpectedExceptionName = "StateMachine.TransitionDoesNotExistException")]
        public void UnknownTransitionError()
        {
            machine.Start();
            machine.Transition(Transitions.NormalExit);
        }

        [TestCase(ExpectedExceptionName = "StateMachine.TransitionAlreadyExistsException")]
        public void TransitionAlreadyExistsError()
        {
            machine.AddTransition(null, State<FirstState, Transitions>.Instance, Transitions.Start);
        }
    }
}
