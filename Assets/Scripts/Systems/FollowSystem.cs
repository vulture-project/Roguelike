using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class FollowSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent, FollowerComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get1(i);
                ref var follower = ref _filter.Get2(i);

                ref var targetTransform = ref follower.Target.Get<TransformComponent>();

                transform.Transform.forward =
                    (targetTransform.Transform.position - transform.Transform.position).normalized;
            }
        }
    }
}