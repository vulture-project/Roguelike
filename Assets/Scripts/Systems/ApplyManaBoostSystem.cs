using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ApplyManaBoostSystem : IEcsRunSystem
    {
        private EcsFilter<ManaBoostComponent, ManaComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log("Applied Mana Potion");
                ref var manaBoost = ref _filter.Get1(i);
                ref var mana = ref _filter.Get2(i);

                mana.Value = Mathf.Clamp(mana.Value + manaBoost.Value, 0, mana.MaxValue);

                var entity = _filter.GetEntity(i);
                entity.Del<ManaComponent>();
            }
        }
    }
}