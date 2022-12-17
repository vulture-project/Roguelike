﻿using Core;
using Components;
using Prefabs;

using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Factories
{
    public class ProjectileFactory : Singleton<ProjectileFactory>
    {
        [SerializeField]
        private Projectile _fireBlast;

        [SerializeField]
        private Projectile _iceSpike;
        
        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();
        }
        
        public void SpawnFireBlast(Vector3 position, Vector3 direction)
        {
            SpawnProjectile(_fireBlast, position, direction);
        }

        public void SpawnIceSpike(Vector3 position, Vector3 direction)
        {
            SpawnProjectile(_iceSpike, position, direction);
        }
        
        private void SpawnProjectile(Projectile projectile, Vector3 position, Vector3 direction)
        {
            var clone = Instantiate(projectile.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(_fireBlast.Damage);
            entity.Replace(new DamageSourceTag());
            entity.Replace(new TransformComponent(clone.GetComponent<Transform>()));
            entity.Replace(_fireBlast.Velocity);

            clone.transform.forward = direction;
            clone.GetComponent<Entity>().Set(entity);
        }
    }
}