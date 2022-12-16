using AI.Common.Watch;
using System;

namespace AI.Interaction
{
    public class SpottingManager
    {
        public event EventHandler EnemySpotted;

        public void DispatchEnemySpotted(object sender, EventArgs args)
        {
            EnemySpotted?.Invoke(this, args);
        }
    }
}