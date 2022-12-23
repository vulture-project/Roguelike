using AI.Base;
using AI.Common.Events;
using AI.Common.Roam;
using AI.Configs.Archer.Fight;
using AI.Interaction;
using AI.Common.Animations;
using UnityEngine;
using AI.Configs.Archer.Fight.Animations;

namespace AI.Configs.Archer
{
    public class MasterStateMachine : StateMachine
    {
        private readonly MovementNotifier _movementNotifier;

        private State _hitAnimationState;
        private State _diedState;

        public MasterStateMachine(GameObject agent,
                                  MasterStateMachineConfig config,
                                  GameObject enemy, SpottingManager spottingManager,
                                  AnimationNotifier animationNotifier)
        {
            _movementNotifier = new MovementNotifier();

            RoamStateMachine = new RoamStateMachine(agent, config.RoamStateMachineConfig);
            FightStateMachine = new FightStateMachine(agent, config.FightStateMachineConfig,
                                                      enemy, _movementNotifier,
                                                      animationNotifier);
            MergeCore(this, RoamStateMachine);
            MergeCore(this, FightStateMachine);

            InitRoamToFightTransition(spottingManager);

            BuildHitAnimationState(animationNotifier);
            BuildDiedState(animationNotifier);

            EntryState = RoamStateMachine.EntryState;
        }

        public RoamStateMachine RoamStateMachine { get; }
        public FightStateMachine FightStateMachine { get; }

        private void InitRoamToFightTransition(SpottingManager spottingManager)
        {
            var roamToFightDecision = new RoamToFightDecision(spottingManager);
            var roamToFightTransition = new Transition(roamToFightDecision, FightStateMachine.EntryState);
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