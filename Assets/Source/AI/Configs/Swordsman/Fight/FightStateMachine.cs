using AI.Base;
using AI.Common.Chase;
using AI.Common.Events;
using UnityEngine;
using AI.Common.Animations;
using AI.Configs.Swordsman.Fight.Stuff;

namespace AI.Configs.Swordsman.Fight
{
    public class FightStateMachine : StateMachine
    {
        public FightStateMachine(GameObject agent,
                                 MovementNotifier movementNotifier,
                                 AnimationNotifier animationNotifier,
                                 GameObject enemy)
        {
            _chaseStateMachine = new ChaseStateMachine(agent, enemy,
                                                       movementNotifier);
            MergeCore(this, _chaseStateMachine);

            var fighter = new Fighter(agent, enemy, 2.0f);
            var attackAction = new AttackAction(fighter);
            _chaseStateMachine.CatchState.AddAction(attackAction);

            BuildAttackAnimationState(agent, animationNotifier);

            EntryState = _chaseStateMachine.EntryState;
        }

        public State AttackAnimationState { get; private set; }

        private void BuildAttackAnimationState(GameObject agent, AnimationNotifier animationNotifier)
        {
            AttackAnimationState = new State();
            BuildAttackAnimationTransition(agent, animationNotifier);
            AddStateToList(AttackAnimationState);
        }

        private void BuildAttackAnimationTransition(GameObject agent, AnimationNotifier animationNotifier)
        {
            var toDecision = new ToMutingAnimationDecision(agent);
            animationNotifier.AttackAnimationStarted += toDecision.OnAnimationStarted;

            var fromDecision = new FromMutingAnimationDecision(agent);
            animationNotifier.AttackAnimationFinished += fromDecision.OnAnimationFinished;

            var toTransition = new Transition(toDecision, AttackAnimationState);
            var fromTransition = new Transition(fromDecision, toTransition);

            AddTransitionToAllStates(toTransition);
            AttackAnimationState.AddTransition(fromTransition);
        }

        private ChaseStateMachine _chaseStateMachine;
    }
}