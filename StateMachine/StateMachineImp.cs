using System.Collections.Generic;

namespace StateMachine
{
    internal class StateMachineImp<T, THandler> : IStateMachine<T> where THandler : IActionHandler<T>
    {
        private struct MachineKey
        {
            public IState<T> state;
            public T transition;
        }

        private readonly Dictionary<MachineKey, IState<T>> transitions;
        private readonly THandler handler;

        internal StateMachineImp(THandler handler)
        {
            transitions = new Dictionary<MachineKey, IState<T>>();
            this.handler = handler;
            this.handler.StateMachine = this;
        }

        #region Implementation of IStateMachine

        public void AddTransition(IState<T> currentState, IState<T> nextState, T transitionType)
        {
            MachineKey key = new MachineKey {state = currentState, transition = transitionType};
            if (transitions.ContainsKey(key))
            {
                throw new TransitionAlreadyExistsException(key.state == null ? "No State" : key.state.ToString(), key.transition.ToString());
            }
            transitions[key] = nextState;
        }

        public void Transition(T transition)
        {
            if (!IsRunning)
            {
                throw new StateMachineNotRunningException();
            }

            MachineKey key = new MachineKey { state = (IState<T>) this.State, transition = transition };
            if (!transitions.ContainsKey(key))
            {
                throw new TransitionDoesNotExistException(key.state == null ? "No State" : key.state.ToString(), key.transition.ToString());
            }
            State = transitions[key];
            if (handler.IsTerminal(transition))
            {
                IsRunning = false;
            }
            if (State != null)
            {
                State.Run(this);
            }
        }

        public IState<T> State { get; private set; }

        public bool IsRunning { get; private set; }

        public void Start()
        {
            IsRunning = true;
            this.State = null;
            Transition(handler.Start);
        }

        #endregion
    }
}