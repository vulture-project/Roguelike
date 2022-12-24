using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ApplyHealSystem : IEcsRunSystem
    {
        private EcsFilter<HealComponent, HealthComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log("Applied Heal Potion");
                ref var heal = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                health.Value = Mathf.Clamp(health.Value + heal.Value, 0, health.MaxValue);

                var entity = _filter.GetEntity(i);
                entity.Del<HealComponent>();
            }
        }
    }
}