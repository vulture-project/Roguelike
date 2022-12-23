using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SpellImpactSystem : IEcsRunSystem
    {
        private EcsFilter<DestroyTag, TransformComponent, SpellImpactComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transform = ref _filter.Get2(i);
                ref var impact = ref _filter.Get3(i);

                GameObject.Instantiate(impact.ImpactPrefab, transform.Transform.position, Quaternion.identity);
            }
        }
    }
}