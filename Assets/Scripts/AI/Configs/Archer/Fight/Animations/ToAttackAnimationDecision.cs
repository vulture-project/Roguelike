using AI.Base;
using System;

namespace AI.Configs.Archer.Fight.Animations
{
    public class ToAttackAnimationDecision : ADecision
    {
        public ToAttackAnimationDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.AttackStartedEvent += OnAttackAnimationStarted;
        }

        public override bool Decide()
        {
            if (_attackAnimationStarted)
            {
                _attackAnimationStarted = false;
                return true;
            }
            return false;
        }

        private void OnAttackAnimationStarted(object sender, EventArgs args)
        {
            _attackAnimationStarted = true;
        }

        private bool _attackAnimationStarted = false;
    }
}