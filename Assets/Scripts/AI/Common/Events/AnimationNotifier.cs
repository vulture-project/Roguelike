using System;

namespace AI.Common.Events
{
    public class AnimationNotifier
    {
        public event EventHandler AttackAnimationStarted;
        public event EventHandler AttackAnimationFinished;

        public void DispatchAttackAnimationStarted(object sender, EventArgs args)
        {
            AttackAnimationStarted?.Invoke(sender, args);
        }

        public void DispatchAttackAnimationFinished(object sender, EventArgs args)
        {
            AttackAnimationFinished?.Invoke(sender, args);
        }
    }
}