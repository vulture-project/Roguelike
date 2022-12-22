using UnityEngine;
using System;

namespace AI.Configs.Swordsman.Fight.Animations
{
    public class AnimationNotifier : MonoBehaviour
    {
        public event EventHandler AttackStartedEvent;
        public event EventHandler AttackFinishedEvent;

        public event EventHandler HitStartedEvent;
        public event EventHandler RecoveredFromHitEvent;

        public void AttackStarted()
        {
            AttackStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void AttackFinished()
        {
            AttackFinishedEvent?.Invoke(this, EventArgs.Empty);
        }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        public void HitStarted()
        {
            HitStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void RecoveredFromHit()
        {
            RecoveredFromHitEvent?.Invoke(this, EventArgs.Empty);
        }
        
>>>>>>> Stashed changes
        public void Died()
        {
            Destroy(gameObject);
        }
    }
}