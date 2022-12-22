using UnityEngine;
using System;

namespace AI.Configs.Swordsman.Fight.Animations
{
    public class AnimationNotifier : MonoBehaviour
    {
        public event EventHandler AttackStartedEvent;
        public event EventHandler AttackFinishedEvent;

        public void AttackStarted()
        {
            AttackStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void AttackFinished()
        {
            AttackFinishedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Died()
        {
            Destroy(gameObject);
        }
    }
}