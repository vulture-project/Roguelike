using AI.Common.Chase;
using AI.Common.Components;
using AI.Common.Dodge;
using AI.Common.Roam;
using AI.Common.Watch;
using AI.Configs.Archer;
using AI.Configs.Archer.Fight;
using Utils.Math;
using Core;
using Components;
using Prefabs;
using UnityComponents;

using Leopotam.Ecs;

using UnityEngine;

namespace Factories
{
    public class  LichFactory : Singleton<LichFactory>
    {
        [SerializeField]
        private Lich _lich;
        
        private Camera _mainCamera;

        private int _velocityZHash;
        private int _hitImpactHash;
        private int _diedHash;

        private EcsWorld _world;

        public void Init()
        {
            SetInstance(this);

            _world = World.Instance().Get();

            _velocityZHash = Animator.StringToHash("speedZ");
            _hitImpactHash = Animator.StringToHash("hit");
            _diedHash = Animator.StringToHash("deathBlow");
            _mainCamera = Camera.main;
        }

        public void Spawn(Vector3 position, GameObject navMeshRoom, GameObject enemy)
        {
            var clone = Instantiate(_lich.Prefab, position, Quaternion.identity);
            var fov = clone.GetComponent<FieldOfView>();
            fov.Value = 20.0f;

            var catchComp = clone.GetComponent<Catch>();
            catchComp.Value = 10.0f;

            // FIXME: God I'm sorry for this!
            GameObject canvas = clone.transform.Find("CanvasForHP").gameObject;
            canvas.GetComponent<Canvas>().worldCamera = Camera.main;
            
            Bar healthBar = canvas.transform.Find("Health").gameObject.GetComponent<Bar>();
            
            var entity = _world.NewEntity();
            entity.Replace(_lich.Armour);
            entity.Replace(new NavMeshAgentComponent(clone.GetComponent<UnityEngine.AI.NavMeshAgent>()));
            entity.Replace(new AttachedHealthBarComponent(healthBar));
            entity.Replace(new AnimatorComponent(clone.GetComponent<Animator>()));
            entity.Replace(new DamageTargetTag());
            entity.Replace(_lich.Health);
            entity.Replace(new InputComponent());
            entity.Replace(new MovementForwardAnimationComponent(_velocityZHash));
            entity.Replace(new HitImpactAnimationComponent(_hitImpactHash));
            entity.Replace(new DeathAnimationComponent(_diedHash));
            entity.Replace(new TransformComponent(clone.GetComponent<Transform>()));
            entity.Replace(_lich.Velocity);

            entity.Replace(new GameObjectComponent(clone));
            
            clone.GetComponent<Entity>().Set(entity);

            var firePoint = clone.GetComponent<FirePoint>();
            
            RoamStateMachineConfig roamStateMachineConfig = new RoamStateMachineConfig(new Range(1, 2), new Range(3, 4));
            DodgeStateMachineConfig dodgeStateMachineConfig =
                new DodgeStateMachineConfig(new RoamStateMachineConfig(new Range(0, 0), new Range(3, 4)), new Range(2, 3));
            FightStateMachineConfig fightStateMachineConfig = new FightStateMachineConfig(dodgeStateMachineConfig, 
                new TimeoutChaseStateMachineConfig(new Range(3, 4)), firePoint.GetTransform(), 2, 0.25f, ProjectileType.FireBlast);
            MasterStateMachineConfig masterStateMachineConfig =
                new MasterStateMachineConfig(roamStateMachineConfig, fightStateMachineConfig);

            clone.GetComponent<Archer>().Init(navMeshRoom, enemy, new MasterStateMachineConfig(roamStateMachineConfig, fightStateMachineConfig));
        }
    }
}