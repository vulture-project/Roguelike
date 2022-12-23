using AI.Common.Roam;
using AI.Configs.Swordsman;
using AI.Configs.Swordsman.Fight;
using Components;
using Core;
using Leopotam.Ecs;
using Prefabs;
using UnityComponents;
using UnityEngine;
using Utils.Math;

namespace Factories
{
    public class SpiderFactory : Singleton<SpiderFactory>
    {
        [SerializeField]
        private Spider _spider;

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
            var clone = Instantiate(_spider.Prefab, position, Quaternion.identity);

            // FIXME: God I'm sorry for this!
            GameObject canvas = clone.transform.Find("CanvasForHP").gameObject;
            canvas.GetComponent<Canvas>().worldCamera = Camera.main;
            
            Bar healthBar = canvas.transform.Find("Health").gameObject.GetComponent<Bar>();
            
            var entity = _world.NewEntity();
            entity.Replace(_spider.Armour);
            entity.Replace(new NavMeshAgentComponent(clone.GetComponent<UnityEngine.AI.NavMeshAgent>()));
            entity.Replace(new AttachedHealthBarComponent(healthBar));
            entity.Replace(new AnimatorComponent(clone.GetComponent<Animator>()));
            entity.Replace(new DamageTargetTag());
            entity.Replace(new PotionDropTag());
            entity.Replace(_spider.Health);
            entity.Replace(new InputComponent());
            entity.Replace(new MovementForwardAnimationComponent(_velocityZHash));
            entity.Replace(new HitImpactAnimationComponent(_hitImpactHash));
            entity.Replace(new DeathAnimationComponent(_diedHash));
            entity.Replace(new TransformComponent(clone.GetComponent<Transform>()));
            entity.Replace(_spider.Velocity);

            entity.Replace(new GameObjectComponent(clone));
            
            clone.GetComponent<Entity>().Set(entity);

            RoamStateMachineConfig roamStateMachineConfig =
                new RoamStateMachineConfig(new Range(1, 2), new Range(1, 2));
            FightStateMachineConfig fightStateMachineConfig = new FightStateMachineConfig(0.5f);
            
            clone.GetComponent<Swordsman>().Init(navMeshRoom, enemy, new MasterStateMachineConfig(roamStateMachineConfig, fightStateMachineConfig));
        }
    }
}