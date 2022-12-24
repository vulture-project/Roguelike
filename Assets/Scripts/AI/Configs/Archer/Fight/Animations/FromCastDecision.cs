using AI.Base;
using System;

namespace AI.Configs.Archer.Fight.Animations
{
    public class FromCastDecision : ADecision
    {
        public FromCastDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.CastingProjectileFinishedEvent += OnCastingFinished;
        }

        public override bool Decide()
        {
            if (_castingFinished)
            {
                _castingFinished = false;
                return true;
            }
            return false;
        }

        private void OnCastingFinished(object sender, EventArgs args)
        {
            _castingFinished = true;
        }

        private bool _castingFinished = false;
    }
}