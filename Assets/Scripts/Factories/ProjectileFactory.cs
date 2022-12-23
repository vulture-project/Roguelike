using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace Factories
{
    public enum ProjectileType
    {
        FireBlast,
        IceSpike,
        MagicBlast
    }
    
    public class ProjectileFactory : Singleton<ProjectileFactory>
    {
        [SerializeField]
        private Projectile _fireBlast;

        [SerializeField]
        private Projectile _iceSpike;

        [SerializeField]
        private Projectile _magicBlast;
        
        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();
        }

        public void Spawn(ProjectileType projectile, Vector3 position, Vector3 direction)
        {
            switch (projectile)
            {
                case ProjectileType.FireBlast:
                    SpawnProjectile(_fireBlast, position, direction);
                    break;
                case ProjectileType.IceSpike:
                    SpawnProjectile(_iceSpike, position, direction);
                    break;
                case ProjectileType.MagicBlast:
                    SpawnProjectile(_magicBlast, position, direction);
                    break;
            }
        }

        private void SpawnProjectile(Projectile projectile, Vector3 position, Vector3 direction)
        {
            var clone = Instantiate(projectile.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(projectile.Damage);
            entity.Replace(new DamageSourceTag());
            entity.Replace(new TransformComponent(clone.GetComponent<Transform>()));
            entity.Replace(projectile.Velocity);
            entity.Replace(new GameObjectComponent(clone));
            entity.Replace(new SpellImpactComponent(projectile.ImpactPrefab));

            clone.transform.forward = direction;
            clone.GetComponent<Entity>().Set(entity);
        }
    }
}