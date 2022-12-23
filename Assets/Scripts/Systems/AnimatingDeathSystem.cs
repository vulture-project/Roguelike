using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class AnimatingDeathSystem : IEcsRunSystem
    {
        private EcsFilter<AnimatorComponent, DeathAnimationComponent, DiedTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var animator = ref _filter.Get1(i);
                ref var deathAnimation = ref _filter.Get2(i);
                ref var died = ref _filter.Get3(i);

                animator.Animator.SetTrigger(deathAnimation.DiedHash);
            }
        }
    }
}