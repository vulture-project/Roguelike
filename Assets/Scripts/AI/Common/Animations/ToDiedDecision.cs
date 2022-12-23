using AI.Base;
using System;
using UnityEngine;

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
            return _died;
        }

        private void OnDied(object sender, EventArgs args)
        {
            Debug.Log("died");
            _died = true;
        }

        private bool _died = false;
    }
}