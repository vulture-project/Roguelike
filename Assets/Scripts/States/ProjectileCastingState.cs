using Factories;
using UnityComponents;

using UnityEngine;

namespace States
{
    [RequireComponent(typeof(Animator), typeof(FirePoint))]
    public class ProjectileCastingState : State
    {
        [SerializeField]
        private ProjectileType _projectile;
        
        private Animator _animator;
        private int _castProjectileTriggerHash;
        private FirePoint _firePoint;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _castProjectileTriggerHash = Animator.StringToHash("castProjectile");
            _firePoint = GetComponent<FirePoint>();
        }

        public override void OnEnter()
        {
            _animator.SetTrigger(_castProjectileTriggerHash);
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        public void SetProjectile(ProjectileType projectile)
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