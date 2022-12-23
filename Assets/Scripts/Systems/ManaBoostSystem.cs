using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ManaBoostSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionComponent, ManaBoostComponent, ManaBoostSourceTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var collision = ref _filter.Get1(i);
                ref var manaBoost = ref _filter.Get2(i);
                if (collision.Target.Has<ManaBoostTargetTag>())
                {
                    collision.Target.Replace(manaBoost);

                    var entity = _filter.GetEntity(i);
                    entity.Replace(new DestroyTag());
                }
            }
        }
    }
}