using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace Factories
{
    public class SpeedPotionFactory : Singleton<SpeedPotionFactory>
    {
        [SerializeField]
        private SpeedPotion _speedPotion;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();
        }

        public void Spawn(Vector3 position)
        {
            var clone = Instantiate(_speedPotion.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(_speedPotion.SpeedBoost);
            entity.Replace(new SpeedBoostSourceTag());
            entity.Replace(new GameObjectComponent(clone));

            clone.GetComponent<Entity>().Set(entity);
        }
    }
}