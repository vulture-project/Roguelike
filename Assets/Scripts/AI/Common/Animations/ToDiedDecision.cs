using AI.Base;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

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
            Debug.Log("decides to died");
            if (_died)
                Debug.Log("decision died");
            return _died;
        }

        private void OnDied(object sender, EventArgs args)
        {
            Debug.Log("OnDied");
            _died = true;
        }

        private bool _died = false;
    }
}