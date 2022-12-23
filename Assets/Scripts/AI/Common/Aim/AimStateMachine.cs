using AI.Base;

namespace AI.Common.Aim
{
    public class AimStateMachine : StateMachine
    {
        public AimStateMachine(AimStateMachineConfig config)
        {
            BuildAimState(config);
        }

        private void BuildAimState(AimStateMachineConfig config)
        {
            AimState = new State();
            var aimAction = new AimAction(config.FirePoint, config.Enemy);
            AimState.AddAction(aimAction);
            AddStateToList(AimState);
            EntryState = AimState;
        }

        public State AimState;
    }
}