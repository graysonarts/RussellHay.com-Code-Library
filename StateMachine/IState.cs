namespace StateMachine
{
    /// <summary>
    /// The interface to implement your state.
    /// </summary>
    /// <typeparam name="T">The transition Type</typeparam>
    public interface IState<T>
    {
        /// <summary>
        /// The functionality of the state.  Do something here
        /// </summary>
        /// <param name="machine">The state machine running in</param>
        void Run(IStateMachine<T> machine);
    }
}