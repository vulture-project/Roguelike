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

                // Temporary commented
                // Debug.Log($"Applied damage {damage.Value}, health: {health.Value}/{health.MaxValue} -> {health.Value - damage.Value}/{health.MaxValue}");

                health.Value = Mathf.Clamp(health.Value - damage.Value, 0, health.MaxValue);
                
                var entity = _filter.GetEntity(i);
                entity.Del<DamageComponent>();

                if (health.Value == 0)
                {
                    entity.Replace(new DiedTag());
                }
            }
        }
    }
}