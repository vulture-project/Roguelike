using AI.Common.Animations;
using System;

namespace AI.Configs.Archer.Fight.Animations
{
    public class AnimationNotifier : BaseAnimationNotifier
    {
        public EventHandler ProjectileCastedEvent;

        public void ProjectileCasted()
        {
            ProjectileCastedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}