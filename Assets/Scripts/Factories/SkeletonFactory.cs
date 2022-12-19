using AI.Configs.Swordsman;
using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace Factories
{
    public class SkeletonFactory : Singleton<SkeletonFactory>
    {
        [SerializeField]
        private Skeleton _skeleton;

        private Camera _mainCamera;

        private int _velocityZHash;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();

            _velocityZHash = Animator.StringToHash("speedZ");
            _mainCamera = Camera.main;
        }

        public void Spawn(Vector3 position, GameObject navMeshRoom, GameObject enemy)
        {
            var clone = Instantiate(_skeleton.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(_skeleton.Armour);
            entity.Replace(new NavMeshAgentComponent(clone.GetComponent<UnityEngine.AI.NavMeshAgent>()));
            entity.Replace(new AnimatorComponent(clone.GetComponent<Animator>()));
            entity.Replace(new DamageTargetTag());
            entity.Replace(_skeleton.Health);
            entity.Replace(new InputComponent());
            entity.Replace(new MovementForwardAnimationComponent(_velocityZHash));
            entity.Replace(new TransformComponent(clone.GetComponent<Transform>()));
            entity.Replace(_skeleton.Velocity);

            clone.GetComponent<Entity>().Set(entity);
            clone.GetComponent<Swordsman>().Init(navMeshRoom, enemy);
        }
    }
}