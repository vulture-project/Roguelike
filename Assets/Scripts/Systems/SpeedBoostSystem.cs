using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SpeedBoostSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionComponent, SpeedBoostComponent, SpeedBoostSourceTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var collision = ref _filter.Get1(i);
                ref var speedBoost = ref _filter.Get2(i);
                if (collision.Target.Has<SpeedBoostTargetTag>())
                {
                    if (collision.Target.Has<ActiveAffect>())
                    {
                        collision.Target.Get<ActiveAffect>().DurationLeft = speedBoost.Duration;
                    }
                    else
                    {
                        collision.Target.Replace(speedBoost);
                        collision.Target.Replace(new ActiveAffect(speedBoost.Duration));
                    }

                    var entity = _filter.GetEntity(i);
                    entity.Replace(new DestroyTag());
                }
            }
        }
    }
}