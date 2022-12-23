using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class AnimatingMovementForwardSystem : IEcsRunSystem
    {
        private EcsFilter<AnimatorComponent, MovementForwardAnimationComponent, VelocityComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var animator = ref _filter.Get1(i);
                ref var movementAnimation = ref _filter.Get2(i);
                ref var velocity = ref _filter.Get3(i);

                // animator.Animator.SetFloat(movementAnimation.VelocityXHash, velocity.Value.x);
                animator.Animator.SetFloat(movementAnimation.VelocityZHash, velocity.Value.z / velocity.MaxValue.z);
            }
        }
    }
}