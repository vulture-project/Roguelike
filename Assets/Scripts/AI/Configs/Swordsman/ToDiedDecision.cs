using AI.Base;
using AI.Configs.Swordsman.Fight.Animations;
using System;
using UnityEngine;

namespace AI.Configs.Swordsman
{
    public class ToDiedDecision : ADecision
    {
        public ToDiedDecision(AnimationNotifier animationNotifier)
        {
            animationNotifier.DiedEvent += OnDied;
        }

        public override bool Decide()
        {
            return _died;
        }

        private void OnDied(object sender, EventArgs args)
        {
            _died = true;
        }

        private bool _died = false;
    }
}