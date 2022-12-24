using AI.Base;
using AI.Common.Animations;
using UnityEngine;

namespace AI.Common.Death
{
    public class DeathStateMachine : StateMachine
    {
        public DeathStateMachine(BaseAnimationNotifier animationNotifier, GameObject agent)
        {
            StartedDyingState = new State();
            DiedState = new State();

            DiedState.AddAction(new DieAction(agent));

            var toDiedDecision = new ToDiedDecision(animationNotifier);
            StartedDyingState.AddTransition(new Transition(toDiedDecision, DiedState));
            
            AddStateToList(StartedDyingState);
            AddStateToList(DiedState);

            EntryState = StartedDyingState;
        }

        public State StartedDyingState { get; private set; }
        public State DiedState { get; private set; }
    }
}