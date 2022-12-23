using AI.Configs.Archer.Fight.Animations;
using UnityEngine;
using Utils.Math;
using Utils.Time;
using System;
using Factories;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Arch
    {
        private readonly Transform _firePointTransform;
        private readonly GameObject _agent;
        private readonly float _projectileWidth;
        private readonly float _reloadEps = 1.0f;

        private readonly float _reloadTime;
        private readonly CountdownTimer _timer;

        private readonly Animator _animator;
        private readonly int _attackHash;

        private readonly LayerMask _heroLayerMask;

        private Ray _leftRay;
        private Ray _middleRay;
        private Ray _rightRay;

        private ProjectileType _projectileType;

        public Arch(GameObject agent, AnimationNotifier animationNotifier,
                    float reloadTime, Transform firePoint,
                    float projectileWidth, ProjectileType projectileType)
        {
            animationNotifier.ShootProjectileEvent += OnShootProjectile;
            
            _firePointTransform = firePoint;
            _agent = agent;
            _projectileWidth = projectileWidth;

            _reloadTime = reloadTime;
            _timer = new CountdownTimer();
            _timer.Restart(0.0f);

            _animator = agent.GetComponent<Animator>();
            _attackHash = Animator.StringToHash("castProjectile");

            _heroLayerMask = LayerMask.GetMask("Hero");
        }

        public void TryShoot()
        {
            if (CanShoot())
            {
                _animator.SetTrigger(_attackHash);
                _timer.Restart(_reloadTime + UnityEngine.Random.Range(0, _reloadEps));
            }
        }

        public bool HitsEnemy()
        {
            BuildRays();
            Debug.DrawRay(_leftRay.origin, _leftRay.direction);
            Debug.DrawRay(_middleRay.origin, _middleRay.direction);
            Debug.DrawRay(_rightRay.origin, _rightRay.direction);
            return Points.CheckObjectRaycast(_leftRay, _heroLayerMask) &&
                   Points.CheckObjectRaycast(_middleRay, _heroLayerMask) &&
                   Points.CheckObjectRaycast(_rightRay, _heroLayerMask);
        }

        public bool CanShoot()
        {
            return _timer.IsDown();
        }

        private void BuildRays()
        {
            _middleRay.origin = _agent.transform.position;

            var toRight = 0.5f * _projectileWidth * _agent.transform.right;
            var toLeft = -toRight;

            _leftRay.origin = _middleRay.origin + toLeft;
            _rightRay.origin = _middleRay.origin + toRight;

            _leftRay.direction = _middleRay.direction = _rightRay.direction = _agent.transform.forward;
        }

        private void OnShootProjectile(object sender, EventArgs args)
        {
            ProjectileFactory.Instance().Spawn(_projectileType, _firePointTransform.position, _agent.transform.forward);
        }
    }
}