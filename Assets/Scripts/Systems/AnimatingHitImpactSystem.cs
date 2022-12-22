using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class AnimatingHitImpactSystem : IEcsRunSystem
    {
        private EcsFilter<AnimatorComponent, HitImpactAnimationComponent, DamageComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var animator = ref _filter.Get1(i);
                ref var hitAnimation = ref _filter.Get2(i);
                ref var damage = ref _filter.Get3(i);

                animator.Animator.SetTrigger(hitAnimation.HitImpactHash);
            }
        }
    }
}