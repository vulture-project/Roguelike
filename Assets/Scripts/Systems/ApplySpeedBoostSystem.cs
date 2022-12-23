using System;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ApplySpeedBoostSystem : IEcsRunSystem
    {
        private EcsFilter<SpeedBoostComponent, ActiveAffect, VelocityComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var speedBoost = ref _filter.Get1(i);
                ref var activeAffect = ref _filter.Get2(i);
                ref var velocity = ref _filter.Get3(i);

                if (!activeAffect.Applied)
                {
                    velocity.Value *= speedBoost.Value;
                    velocity.MaxValue *= speedBoost.Value;
                    activeAffect.Applied = true;
                }
                
                activeAffect.DurationLeft -= Time.deltaTime;

                if (activeAffect.DurationLeft <= 0f)
                {
                    velocity.Value /= speedBoost.Value;
                    velocity.MaxValue /= speedBoost.Value;
                    
                    var entity = _filter.GetEntity(i);
                    entity.Del<SpeedBoostComponent>();   
                    entity.Del<ActiveAffect>();   
                }
            }
        }
    }
}