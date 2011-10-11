namespace StateMachine
{
    /// <summary>
    /// Singleton wrapper for States.  Should be used to insure there is only one instance of each state.
    /// </summary>
    /// <typeparam name="T">The IState&lt;T&gt; Type"/></typeparam>
    /// <typeparam name="TAction">The Transition Type</typeparam>
    public class State<T, TAction> where T : class, IState<TAction>, new()
    {
        private static T instance;
        /// <summary>
        /// The singleton Instance
        /// </summary>
        public static T Instance
        {
            get { return instance ?? (instance = new T()); }
        }
    }
}