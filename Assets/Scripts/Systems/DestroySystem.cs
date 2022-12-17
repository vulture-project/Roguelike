using Components;

using Leopotam.Ecs;

using UnityEngine;

namespace Systems
{
    public class DestroySystem : IEcsRunSystem
    {
        private EcsFilter<GameObjectComponent, DestroyTag> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var gameObject = ref _filter.Get1(i);

                Object.Destroy(gameObject.GameObject);

                var entity = _filter.GetEntity(i);
                entity.Destroy();
            }
        }
    }
}