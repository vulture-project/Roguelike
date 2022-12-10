namespace Player
{
    public class WizardMovementState : IState
    {
        private IStateful _stateful;

        public WizardMovementState(IStateful stateful)
        {
            _stateful = stateful;
        }

        public void Update()
        {
            
        }
    }
}