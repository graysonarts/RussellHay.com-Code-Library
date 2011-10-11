namespace StateMachine
{
    /// <summary>
    /// StateMachine Factory
    /// </summary>
    public static class StateMachine 
    {
        /// <summary>
        /// Create a specific state machine for T transitions, with an IActionHandler&lt;T&gt; of THandler
        /// </summary>
        /// <returns>Created StateMachine</returns>
        static public IStateMachine<T> Create<T, THandler>() where THandler : IActionHandler<T>, new()
        {
            return new StateMachineImp<T, THandler>(new THandler());
        }
    }
}
