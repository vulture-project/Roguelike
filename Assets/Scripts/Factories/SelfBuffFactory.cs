using Components;
using Core;
using Prefabs;
using UnityComponents;

using Leopotam.Ecs;

using UnityEngine;

namespace Factories
{
    public class SelfBuffFactory : Singleton<SelfBuffFactory>
    {
        [SerializeField] 
        private SelfBuff _selfBuff;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();
        }

        public void Spawn(GameObject owner)
        {
            var clone = Instantiate(_selfBuff.Prefab, _selfBuff.Prefab.transform.position + owner.transform.position,
                Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(new TransformComponent(clone.transform));
            entity.Replace(new FollowerComponent(owner.GetComponent<Entity>().Get(), _selfBuff.Prefab.transform.position));

            clone.GetComponent<Entity>().Set(entity);
        }
    }
}