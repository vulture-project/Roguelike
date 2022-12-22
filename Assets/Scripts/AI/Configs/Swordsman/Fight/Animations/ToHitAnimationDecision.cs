using AI.Base;
using System;

namespace AI.Configs.Swordsman.Fight.Animations
{
    public class ToHitAnimationDecision : ADecision
    {
        public ToHitAnimationDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.HitStartedEvent += OnHitStarted;
        }

        public override bool Decide()
        {
            if (_hitStarted)
            {
                _hitStarted = false;
                return true;
            }
            return false;
        }

        private void OnHitStarted(object sender, EventArgs args)
        {
            _hitStarted = true;
        }

        private bool _hitStarted = false;
    }
}