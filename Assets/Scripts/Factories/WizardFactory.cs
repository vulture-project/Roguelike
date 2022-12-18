using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;

namespace Factories
{
    public class WizardFactory : Singleton<WizardFactory>
    {
        [SerializeField]
        private Wizard _wizard;

        private Camera _mainCamera;

        private int _velocityXHash;
        private int _velocityZHash;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();

            _velocityXHash = Animator.StringToHash("velocityX");
            _velocityZHash = Animator.StringToHash("velocityZ");
            _mainCamera = Camera.main;
        }

        public void Spawn(Vector3 position)
        {
            var clone = Instantiate(_wizard.Prefab, position, Quaternion.identity);

            var entity = _world.NewEntity();
            entity.Replace(_wizard.Acceleration);
            entity.Replace(_wizard.Armour);
            entity.Replace(new AnimatorComponent(clone.GetComponent<Animator>()));
            entity.Replace(new CameraComponent(_mainCamera));
            entity.Replace(new DamageTargetTag());
            entity.Replace(_wizard.Health);
            entity.Replace(new HealTargetTag());
            entity.Replace(new InputComponent());
            entity.Replace(_wizard.LayerMask);
            entity.Replace(new MovementAnimationComponent(_velocityXHash, _velocityZHash));
            entity.Replace(new TransformComponent(clone.GetComponent<Transform>()));
            entity.Replace(_wizard.Velocity);

            clone.GetComponent<Entity>().Set(entity);
        }
    }
}