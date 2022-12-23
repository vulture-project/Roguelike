using UnityEngine;
using System;

namespace AI.Common.Animations
{
    public class BaseAnimationNotifier : MonoBehaviour
    {
        public event EventHandler AttackStartedEvent;
        public event EventHandler AttackFinishedEvent;

        public event EventHandler HitStartedEvent;
        public event EventHandler RecoveredFromHitEvent;

        public event EventHandler StartedDyingEvent;
        public event EventHandler DiedEvent;

        public virtual void AttackStarted()
        {
            AttackStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public virtual void AttackFinished()
        {
            AttackFinishedEvent?.Invoke(this, EventArgs.Empty);
        }

        public virtual void HitStarted()
        {
            HitStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public virtual void RecoveredFromHit()
        {
            RecoveredFromHitEvent?.Invoke(this, EventArgs.Empty);
        }

        public virtual void StartedDying()
        {
            StartedDyingEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}