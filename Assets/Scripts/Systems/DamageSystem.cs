using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class DamageSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionComponent, DamageComponent, DamageSourceTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var collision = ref _filter.Get1(i);
                ref var damage = ref _filter.Get2(i);
                if (collision.Target.Has<DamageTargetTag>()) collision.Target.Replace(damage);

                var entity = _filter.GetEntity(i);
                entity.Replace(new DestroyTag());
            }
        }
    }
}