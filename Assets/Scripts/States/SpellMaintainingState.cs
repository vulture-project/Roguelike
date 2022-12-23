using Factories;
using UnityComponents;
using UnityEngine;

namespace States
{
    [RequireComponent(typeof(Animator), typeof(FirePoint))]
    public class SpellMaintainingState : State
    {
        private Animator _animator;
        private int _castMaintainHash;
        private FirePoint _firePoint;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _castMaintainHash = Animator.StringToHash("castMaintain");
            _firePoint = GetComponent<FirePoint>();
        }

        public override void OnEnter()
        {
            _animator.SetBool(_castMaintainHash, true);
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
            ProjectileFactory.Instance().SpawnIceSpike(_firePoint.Position(), transform.forward);
        }

        public void MaintainFinished()
        {
            if (!Input.GetButton("Fire2")) _stateSwitch.SwitchTo<IdleState>();
        }
    }
}