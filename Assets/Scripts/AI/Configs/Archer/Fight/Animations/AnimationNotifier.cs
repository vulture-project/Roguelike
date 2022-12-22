using System;
using UnityEngine;

namespace AI.Configs.Archer.Fight.Animations
{
    public class AnimationNotifier : MonoBehaviour
    {
        public EventHandler AttackStartedEvent;
        public EventHandler ProjectileCastedEvent;
        public EventHandler AttackFinishedEvent;

        public void AttackStarted()
        {
            AttackStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void ProjectileCasted()
        {
            ProjectileCastedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void AttackFinished()
        {
            AttackStartedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}