using AI.Base;
using AI.Common.Events;
using AI.Common.Roam;
using AI.Common.Animations;
using AI.Common.Death;
using AI.Configs.Archer.Fight;
using AI.Interaction;
using UnityEngine;
using AI.Configs.Archer.Fight.Animations;

namespace AI.Configs.Archer
{
    public class MasterStateMachine : StateMachine
    {
        private readonly MovementNotifier _movementNotifier;

        private State _hitAnimationState;
        
        private DeathStateMachine DeathStateMachine;

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
            InitRoamToFightTransition(spottingManager);
            DeathStateMachine = new DeathStateMachine(animationNotifier, agent);

            MergeCore(this, RoamStateMachine);
            MergeCore(this, FightStateMachine);
            BuildHitAnimationState(animationNotifier);

            BuildTransitionToDeath(animationNotifier);
            MergeCore(this, DeathStateMachine);

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

        private void BuildTransitionToDeath(AnimationNotifier animationNotifier)
        {
            var toDecision = new ToStartedDyingDecision(animationNotifier);
            var toTransition = new Transition(toDecision, DeathStateMachine.EntryState);
            AddTransitionToAllStates(toTransition);
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