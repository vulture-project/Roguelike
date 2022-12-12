using UnityEngine;

namespace States
{
    public class CastingProjectileState : State
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float velocity;
        [SerializeField] private GameObject firePoint;

        private Animator _animator;
        private int _isCastingProjectileHash;
        private Transform _transform;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _isCastingProjectileHash = Animator.StringToHash("isCastingProjectile");
            _transform = transform;
        }

        public override void OnEnter()
        {
            _animator.SetBool(_isCastingProjectileHash, true);
        }
    
        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            _animator.SetBool(_isCastingProjectileHash, false);
        }

        public void ShootProjectile()
        {
            var projectile = Instantiate(projectilePrefab, firePoint.transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = _transform.forward * velocity;
        }

        public void ProjectileCastingFinished()
        {
            _stateSwitch.Switch(StateType.Idle);
        }
    }
}