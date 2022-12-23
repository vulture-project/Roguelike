using AI.Base;
using AI.Common.Events;
using AI.Common.Roam;
using AI.Configs.Swordsman.Fight;
using AI.Interaction;
using AI.Common.Animations;
using AI.Configs.Swordsman.Fight.Animations;
using UnityEngine;

namespace AI.Configs.Swordsman
{
    public class MasterStateMachine : StateMachine
    {

        private readonly FightStateMachine FightStateMachine;
        private readonly RoamStateMachine RoamStateMachine;

        private State _hitAnimationState; 
        private State _diedState;

        public MasterStateMachine(GameObject agent, GameObject enemy,
                                  MasterStateMachineConfig config,
                                  SpottingManager spottingManager,
                                  AnimationNotifier animationNotifier)
        {
            var movementNotifier = new MovementNotifier();

            RoamStateMachine = new RoamStateMachine(agent, config.RoamStateMachineConfig);
            FightStateMachine = new FightStateMachine(agent, config.FightStateMachineConfig,
                                                      movementNotifier,
                                                      animationNotifier, enemy);

            MergeCore(this, RoamStateMachine);
            MergeCore(this, FightStateMachine);
            BuildRoamToFightTransition(spottingManager);

            BuildHitAnimationState(animationNotifier);
            BuildDiedState(animationNotifier);

            EntryState = RoamStateMachine.EntryState;
        }

        private void BuildRoamToFightTransition(SpottingManager spottingManager)
        {
            var roamToFightDecision = new RoamToFightDecision(spottingManager);
            var roamToFightTransition = new Transition(roamToFightDecision,
                FightStateMachine.EntryState);
            RoamStateMachine.AddTransitionToAllStates(roamToFightTransition);
        }

        private void BuildDiedState(AnimationNotifier animationNotifier)
        {
            _diedState = new State();
            BuildDiedStateTransition(animationNotifier);
            AddStateToList(_diedState);
        }

        private void BuildDiedStateTransition(AnimationNotifier animationNotifier)
        {
            var toDiedDecision = new ToDiedDecision(animationNotifier);
            var toDiedTransition = new Transition(toDiedDecision, _diedState);
            AddTransitionToAllStates(toDiedTransition);
        }

        private void BuildHitAnimationState(AnimationNotifier animationNotifier)
        {
            _hitAnimationState = new State();
            BuildHitAnimationTransition(animationNotifier);
            AddStateToList(_hitAnimationState);
        }

        private void BuildHitAnimationTransition(AnimationNotifier animationNotifier)
        {
            var toDecision = new ToHitAnimationDecision(animationNotifier);
            var fromDecision = new FromHitAnimationDecision(animationNotifier);

            var toTransition = new Transition(toDecision, _hitAnimationState);
            var fromTransition = new Transition(fromDecision, toTransition);

            AddTransitionToAllStates(toTransition);
            _hitAnimationState.AddTransition(fromTransition);
        }
    }
}