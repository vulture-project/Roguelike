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
                var entity = _filter.GetEntity(i);
                var gameObject = _filter.Get1(i).GameObject;
                
                entity.Destroy();
                Object.Destroy(gameObject);
            }
        }
    }
}