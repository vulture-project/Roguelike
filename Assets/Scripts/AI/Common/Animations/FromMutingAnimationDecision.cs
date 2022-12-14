using System;
using AI.Base;
using UnityEngine;

namespace AI.Common.Animations
{
    public class FromMutingAnimationDecision : ADecision
    {
        public FromMutingAnimationDecision(GameObject agent)
        {
            var eventReceiver = agent.GetComponent<EventReceiver>();
            eventReceiver.AttackFinishedEvent += OnAnimationFinished;
        }
        
        public override bool Decide()
        {
            if (_animationFinished)
            {
                _animationFinished = false;
                return true;
            }
            return false;
        }

        public void OnAnimationFinished(object sender, EventArgs args)
        {
            _animationFinished = true;
        }

        private bool _animationFinished = false;

    }
}
