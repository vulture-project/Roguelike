using System;
using AI.Base;

namespace AI.Common.Animations
{
    public class FromAttackAnimationDecision : ADecision
    {
        public FromAttackAnimationDecision(BaseAnimationNotifier animationNotifier)
        {
            animationNotifier.AttackFinishedEvent += OnAttackAnimationFinished;
            animationNotifier.HitStartedEvent += OnHitStarted;
        }

        public override bool Decide()
        {
            if (_attackAnimationFinished)
            {
                _attackAnimationFinished = false;
                return true;
            }
            return false;
        }

        private void OnAttackAnimationFinished(object sender, EventArgs args)
        {
            _attackAnimationFinished = true;
        }

        private void OnHitStarted(object sender, EventArgs args)
        {
            _attackAnimationFinished = true;
        }

        private bool _attackAnimationFinished = false;
    }
}