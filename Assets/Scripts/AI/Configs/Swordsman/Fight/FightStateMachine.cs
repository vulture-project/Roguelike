using AI.Base;
using AI.Common.Chase;
using AI.Common.Events;
using AI.Common.Animations;
using AI.Configs.Swordsman.Fight.Stuff;
using AI.Configs.Swordsman.Fight.Animations;
using UnityEngine;

namespace AI.Configs.Swordsman.Fight
{
    public class FightStateMachine : StateMachine
    {
        private readonly ChaseStateMachine _chaseStateMachine;

        public FightStateMachine(GameObject agent,
                                 FightStateMachineConfig config,
                                 MovementNotifier movementNotifier,
                                 AnimationNotifier animationNotifier,
                                 GameObject enemy)
        {
            _chaseStateMachine = new ChaseStateMachine(agent, enemy,
                movementNotifier);
            MergeCore(this, _chaseStateMachine);

            var fighter = new Fighter(agent, config.ReloadTime);
            var attackAction = new AttackAction(fighter);
            _chaseStateMachine.CatchState.AddAction(attackAction);

            BuildAttackAnimationState(animationNotifier);

            EntryState = _chaseStateMachine.EntryState;
        }

        public State AttackAnimationState { get; private set; }

        private void BuildAttackAnimationState(AnimationNotifier animationNotifier)
        {
            AttackAnimationState = new State();
            BuildAttackAnimationTransition(animationNotifier);
            AddStateToList(AttackAnimationState);
        }

        private void BuildAttackAnimationTransition(AnimationNotifier animationNotifier)
        {
            var toDecision = new ToAttackAnimationDecision(animationNotifier);
            var fromDecision = new FromAttackAnimationDecision(animationNotifier);

            var toTransition = new Transition(toDecision, AttackAnimationState);
            var fromTransition = new Transition(fromDecision, toTransition);

            AddTransitionToAllStates(toTransition);
            AttackAnimationState.AddTransition(fromTransition);
        }
    }
}