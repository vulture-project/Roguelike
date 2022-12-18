using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class HealSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionComponent, HealComponent, HealSourceTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var collision = ref _filter.Get1(i);
                ref var heal = ref _filter.Get2(i);
                if (collision.Target.Has<HealTargetTag>())
                {
                    collision.Target.Replace(heal);

                    var entity = _filter.GetEntity(i);
                    entity.Replace(new DestroyTag());
                }
            }
        }
    }
}