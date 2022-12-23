using AI.Base;
using System;

namespace AI.Common.Animations
{
    public class ToStartedDyingDecision : ADecision
    {
        public ToStartedDyingDecision(BaseAnimationNotifier animationNotifier)
        {
            animationNotifier.StartedDyingEvent += OnStartedDying;
        }

        public override bool Decide()
        {
            return _startedDying;
        }

        private void OnStartedDying(object sender, EventArgs args)
        {
            _startedDying = true;
        }

        private bool _startedDying = false;
    }
}