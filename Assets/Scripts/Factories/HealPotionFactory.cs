using Components;
using Core;
using Prefabs;
using UnityComponents;

using Leopotam.Ecs;

using UnityEngine;

namespace Factories
{
    public class HealPotionFactory : Singleton<HealPotionFactory>
    {
        [SerializeField]
        private HealPotion _healPotion;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();
        }

        public void Spawn(Vector3 position)
        {
            var clone = Instantiate(_healPotion.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(_healPotion.Heal);
            entity.Replace(new HealSourceTag());
            entity.Replace(new GameObjectComponent(clone));

            clone.GetComponent<Entity>().Set(entity);
        }
    }
}