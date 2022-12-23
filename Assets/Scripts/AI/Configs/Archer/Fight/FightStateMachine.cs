using UnityEngine;
using AI.Base;
using AI.Common.Chase;
using AI.Common.Events;
using AI.Common.Dodge;
using AI.Common.Animations;
using AI.Configs.Archer.Fight.Animations;
using AI.Configs.Archer.Fight.Stuff;

namespace AI.Configs.Archer.Fight
{
    public class FightStateMachine : StateMachine
    {
        private readonly TimeoutChaseStateMachine _chaseStateMachine;
        private readonly DodgeStateMachine _dodgeStateMachine;

        public FightStateMachine(GameObject agent, FightStateMachineConfig config,
                                 GameObject enemy, MovementNotifier movementNotifier,
                                 AnimationNotifier animationNotifier)
        {
            var attackAction = BuildAttackAction(agent, config);

            attackAction.NeedToComeCloser += movementNotifier.DispatchNeedToComeCloser;

            _chaseStateMachine = new TimeoutChaseStateMachine(agent, enemy,
                                                              movementNotifier,
                                                              config.TimeoutChaseStateMachineConfig);
            _dodgeStateMachine = new DodgeStateMachine(agent, config.DodgeStateMachineConfig);

            ConnectChaseAndDodge();
            MergeCore(this, _chaseStateMachine);
            MergeCore(this, _dodgeStateMachine);
            AddActionToAllStates(attackAction);
            BuildAttackAnimationState(animationNotifier);
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

        private AttackAction BuildAttackAction(GameObject agent,
                                               FightStateMachineConfig config)
        {
            var arch = new Arch(agent, config.ReloadTime, config.FirePoint, config.ProjectileWidth);
            var fighter = new Fighter(arch);
            return new AttackAction(fighter);
        }

        private void BuildAttackAnimationState(AnimationNotifier animationNotifier)
        {
            AttackAnimationState = new State();
            BuildAttackAnimationTransitions(animationNotifier);
            AddStateToList(AttackAnimationState);
        }

        private void BuildAttackAnimationTransitions(AnimationNotifier animationNotifier)
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