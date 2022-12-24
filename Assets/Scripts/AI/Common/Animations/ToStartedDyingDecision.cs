using AI.Base;
using System;
using UnityEngine;

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
            // Debug.Log("decides to startedDying, _startedDying = " + _startedDying);
            if (_startedDying)
            {
                Debug.Log("started dying decision");
            }
            return _startedDying;
        }

        private void OnStartedDying(object sender, EventArgs args)
        {
            Debug.Log("OnStartedDying");
            _startedDying = true;
        }

        private bool _startedDying = false;
    }
}