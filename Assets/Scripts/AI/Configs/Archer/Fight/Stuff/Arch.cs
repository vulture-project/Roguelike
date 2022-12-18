using UnityEngine;
using Utils.Math;
using Utils.Time;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Arch
    {
        private readonly GameObject _arrowPrefab;

        private readonly Transform _firePointTransform;
        private readonly float _reloadEps = 1.0f;

        private readonly float _reloadTime;
        private readonly CountdownTimer _timer;

        private readonly LayerMask _heroLayerMask;

        private Ray _leftRay;
        private Ray _middleRay;
        private Ray _rightRay;

        public Arch(float reloadTime, Transform firePoint,
            GameObject arrowPrefab)
        {
            _reloadTime = reloadTime;
            _timer = new CountdownTimer();
            _timer.Restart(0.0f);

            _heroLayerMask = LayerMask.GetMask("Hero");

            _firePointTransform = firePoint;
            _arrowPrefab = arrowPrefab;
        }

        public void TryShoot()
        {
            if (CanShoot())
            {
                SpawnArrow();
                _timer.Restart(_reloadTime + Random.Range(0, _reloadEps));
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

        private void SpawnArrow()
        {
            Object.Instantiate(_arrowPrefab,
                _firePointTransform.position,
                Quaternion.LookRotation(
                    _firePointTransform.forward));
        }

        private void BuildRays()
        {
            _middleRay.origin = _firePointTransform.position -
                                _firePointTransform.localScale.x * _firePointTransform.forward;

            var toRight = 0.5f * _firePointTransform.localScale.x * _firePointTransform.right;
            var toLeft = -toRight;

            _leftRay.origin = _middleRay.origin + toLeft;
            _rightRay.origin = _middleRay.origin + toRight;

            _leftRay.direction = _middleRay.direction = _rightRay.direction = _firePointTransform.forward;
        }
    }
}