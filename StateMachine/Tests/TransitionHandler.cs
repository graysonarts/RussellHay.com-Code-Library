namespace StateMachine.Tests
{
    internal class TransitionHandler : IActionHandler<Transitions>
    {
        private readonly Transitions[] terminals;

        public TransitionHandler()
        {
            terminals = new Transitions[]
                            {
                                Transitions.NormalExit, Transitions.ExitWithErrorCode
                            };
        }
        #region Implementation of IActionHandler<Transitions>

        public bool IsTerminal(Transitions action)
        {
            foreach(Transitions trans in terminals)
            {
                if (action == trans)
                    return true;
            }
            return false;
        }

        public Transitions Start { get { return Transitions.Start; } }

        public IStateMachine<Transitions> StateMachine { get; set; }

        #endregion
    }
}