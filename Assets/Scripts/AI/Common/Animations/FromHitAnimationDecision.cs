using AI.Base;
using System;

namespace AI.Common.Animations
{
    public class FromHitAnimationDecision : ADecision
    {
        public FromHitAnimationDecision(BaseAnimationNotifier animationNotifier)
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