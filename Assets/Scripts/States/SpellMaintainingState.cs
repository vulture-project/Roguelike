using Components;
using Factories;
using Prefabs;
using UnityComponents;

using Leopotam.Ecs;

using UnityEngine;

namespace States
{
    [RequireComponent(typeof(Animator), typeof(FirePoint))]
    public class SpellMaintainingState : State
    {
        [SerializeField]
        private Projectile _projectile;
        
        private Animator _animator;
        private int _castMaintainHash;
        private FirePoint _firePoint;
        private Entity _entity;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _castMaintainHash = Animator.StringToHash("castMaintain");
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
                _animator.SetBool(_castMaintainHash, true);    
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
            _animator.SetBool(_castMaintainHash, false);
        }

        public void Maintain()
        {
            ProjectileFactory.Instance().Spawn(_projectile, _firePoint.Position(), transform.forward);
        }

        public void MaintainFinished()
        {
            if (!Input.GetButton("Fire1"))
            {
                _stateSwitch.SwitchTo<IdleState>();
            }
            else
            {
                var entity = _entity.Get();
                ref var mana = ref entity.Get<ManaComponent>();
                if (mana.Value > _projectile.Mana.Value)
                {
                    mana.Value -= _projectile.Mana.Value;
                    _animator.SetBool(_castMaintainHash, true);
                }
                else
                {
                    _stateSwitch.SwitchTo<IdleState>();
                }
            }
        }
    }
}