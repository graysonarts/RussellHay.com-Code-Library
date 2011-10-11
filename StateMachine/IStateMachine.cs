namespace StateMachine
{
    /// <summary>
    /// State Machine Interface
    /// </summary>
    /// <typeparam name="T">Type for transitions (enum or any object type)</typeparam>
    public interface IStateMachine<T>
    {
        /// <summary>
        /// Add a transition from one state to another.
        /// </summary>
        /// <param name="currentState">The from State</param>
        /// <param name="nextState">The to State</param>
        /// <param name="transitionType">The transition value</param>
        void AddTransition(IState<T> currentState, IState<T> nextState, T transitionType);

        /// <summary>
        /// Move the state machine from the current state to the state directed to by transition
        /// </summary>
        /// <param name="transition">The transition</param>
        void Transition(T transition);

        /// <summary>
        /// The current state
        /// </summary>
        IState<T> State { get; }

        /// <summary>
        /// Have we hit a terminal state
        /// </summary>
        bool IsRunning { get;  }

        /// <summary>
        /// Start or Restart the State machine
        /// </summary>
        void Start();
    }
}
