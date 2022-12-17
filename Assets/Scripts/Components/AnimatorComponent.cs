using UnityEngine;

namespace Components
{
    public struct AnimatorComponent
    {
        public readonly Animator Animator;

        public AnimatorComponent(Animator animator)
        {
            Animator = animator;
        }
    }
}