using System;
using AI.Base;
using UnityEngine;

namespace AI.Common.Animations
{
    public class ToMutingAnimationDecision : ADecision
    {
        private bool _animationStarted;

        public ToMutingAnimationDecision(GameObject agent)
        {
            var eventReceiver = agent.GetComponent<EventReceiver>();
            eventReceiver.AttackStartedEvent += OnAnimationStarted;
        }

        public override bool Decide()
        {
            if (_animationStarted)
            {
                _animationStarted = false;
                return true;
            }

            return false;
        }

        public void OnAnimationStarted(object sender, EventArgs args)
        {
            _animationStarted = true;
        }
    }
}