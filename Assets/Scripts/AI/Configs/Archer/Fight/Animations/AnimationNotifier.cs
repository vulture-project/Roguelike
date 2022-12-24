using AI.Common.Animations;
using System;

namespace AI.Configs.Archer.Fight.Animations
{
    public class AnimationNotifier : BaseAnimationNotifier
    {
        public EventHandler CastingProjectileStartedEvent;
        public EventHandler ShootProjectileEvent;
        public EventHandler CastingProjectileFinishedEvent;

        public void CastingProjectileStarted()
        {
            CastingProjectileStartedEvent?.Invoke(this, EventArgs.Empty);
        }
        public void ShootProjectile()
        {
            ShootProjectileEvent?.Invoke(this, EventArgs.Empty);
        }
        public void CastingProjectileFinished()
        {
            CastingProjectileFinishedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}