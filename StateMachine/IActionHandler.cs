namespace StateMachine
{
    /// <summary>
    /// Interface for handling specific parts of the transition Type.
    /// </summary>
    /// <typeparam name="T">Any Type</typeparam>
    public interface IActionHandler<T>
    {
        /// <summary>
        /// Is this a terminal transition?
        /// </summary>
        /// <param name="transition">transition to check for terminal status</param>
        /// <returns></returns>
        bool IsTerminal(T transition);

        /// <summary>
        /// The start transition, there is only one.
        /// </summary>
        T Start { get; }

        /// <summary>
        /// The state machine that the handler is attached to.
        /// </summary>
        IStateMachine<T> StateMachine { get; set; }
    }
}