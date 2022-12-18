using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class HealthBarSystem : IEcsRunSystem
    {
        private EcsFilter<AttachedHealthBarComponent, HealthComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var healthBar = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                healthBar.HealthBar.SetHP((float)health.Value / health.MaxValue);
            }
        }
    }
}