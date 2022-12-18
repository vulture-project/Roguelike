using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace Factories
{
    public class ManaPotionFactory : Singleton<ManaPotionFactory>
    {
        [SerializeField]
        private ManaPotion _manaPotion;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();
        }

        public void Spawn(Vector3 position)
        {
            var clone = Instantiate(_manaPotion.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(_manaPotion.ManaBoost);
            entity.Replace(new ManaBoostSourceTag());
            entity.Replace(new GameObjectComponent(clone));

            clone.GetComponent<Entity>().Set(entity);
        }
    }
}