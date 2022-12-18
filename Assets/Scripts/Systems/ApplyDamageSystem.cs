using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ApplyDamageSystem : IEcsRunSystem
    {
        private EcsFilter<DamageComponent, HealthComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damage = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                health.Value = Mathf.Clamp(health.Value - damage.Value, 0, health.MaxValue);
            }
        }
    }
}