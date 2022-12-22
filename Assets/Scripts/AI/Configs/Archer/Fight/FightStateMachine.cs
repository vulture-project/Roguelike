using AI.Base;
using AI.Common.Chase;
using AI.Common.Events;
using AI.Common.Dodge;
using AI.Configs.Archer.Fight.Stuff;
using UnityEngine;
using Utils.Math;
using AI.Configs.Archer.Fight.Animations;

namespace AI.Configs.Archer.Fight
{
    public class FightStateMachine : StateMachine
    {
        private readonly TimeoutChaseStateMachine _chaseStateMachine;
        private readonly DodgeStateMachine _dodgeStateMachine;

        public FightStateMachine(GameObject agent, Transform firePoint,
                                 float projectileWidth, GameObject enemy,
                                 MovementNotifier movementNotifier,
                                 AnimationNotifier animationNotifier)
        {
            var attackAction = BuildAttackAction(firePoint, projectileWidth, enemy);

            attackAction.NeedToComeCloser += movementNotifier.DispatchNeedToComeCloser;

            _chaseStateMachine = new TimeoutChaseStateMachine(agent, enemy,
                movementNotifier,
                new Range(3, 4));
            // _dodgeStateMachine = new DodgeStateMachine(agent,
            //     new Range(0, 0),
            //     new Range(1, 2),
            //     new Range(3, 4));
            ConnectChaseAndDodge();
            MergeCore(this, _chaseStateMachine);
            MergeCore(this, _dodgeStateMachine);
            AddActionToAllStates(attackAction);
            BuildAttackAnimationState(agent, animationNotifier);
            EntryState = _chaseStateMachine.EntryState;
        }

        public State AttackAnimationState { get; private set; }

        public void ConnectChaseAndDodge()
        {
            _chaseStateMachine.ExitState.AddTransition(
                new Transition(new TrueDecision(),
                    _dodgeStateMachine.EntryState)
            );

            _dodgeStateMachine.ExitState.AddTransition(
                new Transition(new TrueDecision(),
                    _chaseStateMachine.EntryState)
            );
        }

        private AttackAction BuildAttackAction(Transform firePoint,
                                               float projectileWidth,
                                               GameObject enemy)
        {
            // var arch = new Arch(1.5f, firePoint, projectileWidth);
            // var fighter = new Fighter(arch, enemy);
            // return new AttackAction(fighter);
            return null;
        }

        private void BuildAttackAnimationState(GameObject agent, AnimationNotifier animationNotifier)
        {
            AttackAnimationState = new State();
            BuildAttackAnimationTransitions(agent, animationNotifier);
            AddStateToList(AttackAnimationState);
        }

        private void BuildAttackAnimationTransitions(GameObject agent, AnimationNotifier animationNotifier)
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