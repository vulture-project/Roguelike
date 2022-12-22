using System;
using AI.Base;

namespace AI.Configs.Swordsman.Fight.Animations
{
    public class FromAttackAnimationDecision : ADecision
    {
        public FromAttackAnimationDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.AttackFinishedEvent += OnAttackAnimationFinished;
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

        private bool _attackAnimationFinished = false;
    }
}