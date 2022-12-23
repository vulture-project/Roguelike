using System;
using AI.Base;

namespace AI.Configs.Archer.Fight.Animations
{
    public class ToCastDecision : ADecision
    {
        public ToCastDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.CastingProjectileStartedEvent += OnCastingStarted;
        }

        public override bool Decide()
        {
            if (_castingStarted)
            {
                _castingStarted = false;
                return true;
            }
            return false;
        }

        private void OnCastingStarted(object sender, EventArgs args)
        {
            _castingStarted = true;
        }

        private bool _castingStarted = false;
    }
}