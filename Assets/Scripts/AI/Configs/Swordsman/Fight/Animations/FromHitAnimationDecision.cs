using AI.Base;
using System;

namespace AI.Configs.Swordsman.Fight.Animations
{
    public class FromHitAnimationDecision : ADecision
    {
        public FromHitAnimationDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.RecoveredFromHitEvent += OnRecoveredFromHit;
        }

        public override bool Decide()
        {
            if (_recoveredFromHit)
            {
                _recoveredFromHit = false;
                return true;
            }
            return false;
        }

        private void OnRecoveredFromHit(object sender, EventArgs args)
        {
            _recoveredFromHit = true;
        }

        private bool _recoveredFromHit = false;
    }
}