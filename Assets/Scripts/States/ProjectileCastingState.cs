using Factories;
using UnityComponents;
using UnityEngine;

namespace States
{
    [RequireComponent(typeof(Animator), typeof(FirePoint))]
    public class ProjectileCastingState : State
    {
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

        public void ShootProjectile()
        {
            ProjectileFactory.Instance().SpawnFireBlast(_firePoint.Position(), transform.forward);
        }

        public void ProjectileCastingFinished()
        {
            _stateSwitch.SwitchTo<IdleState>();
        }
    }
}