using AI.Base;
using System;
using System.Diagnostics;

namespace AI.Common.Animations
{
    public class ToDiedDecision : ADecision
    {
        public ToDiedDecision(BaseAnimationNotifier animationNotifier)
        {
            animationNotifier.DiedEvent += OnDied;
        }

        public override bool Decide()
        {
            UnityEngine.Debug.Log("died");
            return _died;
        }

        private void OnDied(object sender, EventArgs args)
        {
            _died = true;
        }

        private bool _died = false;
    }
}