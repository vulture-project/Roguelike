using System;
using UnityEngine;

namespace AI.Common.Animations
{
    public class EventReceiver : MonoBehaviour
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