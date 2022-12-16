using AI.Interaction;
using System;
using UnityEngine;

namespace AI.Common.Watch
{
    public class ToWatchDecision : ToWatchDecisionCore
    {
        public ToWatchDecision(GameObject owner, GameObject enemy,
                               SpottingManager spottingManager) :
            base(owner, enemy)
        {
            EnemySpotted += spottingManager.DispatchEnemySpotted;
        }

        public override bool Decide()
        {
            if (base.Decide())
            {
                OnEnemySpotted();
                return true;
            }
            return false;
        }

        public event EventHandler EnemySpotted;

        private void OnEnemySpotted()
        {
            EnemySpotted?.Invoke(this, EventArgs.Empty);
        }
    }
}
