using Components;
using Factories;
using Prefabs;
using UnityComponents;

using Leopotam.Ecs;

using UnityEngine;

namespace States
{
    [RequireComponent(typeof(Animator), typeof(FirePoint))]
    public class ProjectileCastingState : State
    {
        [SerializeField]
        private Projectile _projectile;
        
        private Animator _animator;
        private int _castProjectileTriggerHash;
        private FirePoint _firePoint;
        private Entity _entity;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _castProjectileTriggerHash = Animator.StringToHash("castProjectile");
            _firePoint = GetComponent<FirePoint>();
            _entity = GetComponent<Entity>();
        }

        public override void OnEnter()
        {
            var entity = _entity.Get();
            ref var mana = ref entity.Get<ManaComponent>();
            if (mana.Value > _projectile.Mana.Value)
            {
                mana.Value -= _projectile.Mana.Value;
                _animator.SetTrigger(_castProjectileTriggerHash);    
            }
            else
            {
                _stateSwitch.SwitchTo<IdleState>();
            }
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        public void SetProjectile(Projectile projectile)
        {
            _projectile = projectile;
        }
        
        public void ShootProjectile()
        {
            ProjectileFactory.Instance().Spawn(_projectile, _firePoint.Position(), transform.forward);
        }

        public void ProjectileCastingFinished()
        {
            _stateSwitch.SwitchTo<IdleState>();
        }
    }
}