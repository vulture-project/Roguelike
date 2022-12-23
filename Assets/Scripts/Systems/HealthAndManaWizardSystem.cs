using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class HealthAndManaWizardSystem : IEcsRunSystem
    {
        private EcsFilter<AttachedHpAndManaComponent, HealthComponent, ManaComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var bars = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);
                ref var mana = ref _filter.Get3(i);

                Debug.Log(mana.Value.ToString());
                
                bars.HealthBar.SetHP((float)health.Value / health.MaxValue);
                bars.ManaBar.SetHP((float)mana.Value / mana.MaxValue);
            }
        }
    }
}