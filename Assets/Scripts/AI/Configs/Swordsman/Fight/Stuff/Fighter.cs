using UnityEngine;
using Utils.Math;
using Utils.Time;

namespace AI.Configs.Swordsman.Fight.Stuff
{
    public class Fighter
    {
        private readonly Animator _animator;
        private readonly int _attackHash;

        private GameObject _enemy;

        private Transform _enemyTransform;

        private readonly LayerMask _heroLayerMask;
        private readonly float _reloadTime;

        private Sword _sword;
        private readonly CountdownTimer _timer;

        private readonly Transform _transform;

        public Fighter(GameObject owner, GameObject enemy, float reloadTime)
        {
            _transform = owner.transform;

            _animator = owner.GetComponent<Animator>();
            _attackHash = Animator.StringToHash("attack");

            _enemy = enemy;

            _heroLayerMask = LayerMask.GetMask("Hero");

            _reloadTime = reloadTime;
            _timer = new CountdownTimer();
            _timer.Restart(0.0f);
        }

        public void TryHit()
        {
            if (CanHit())
            {
                _animator.SetTrigger(_attackHash);
                _timer.Restart(_reloadTime);
            }
        }

        public bool CanHit()
        {
            return _timer.IsDown() && CheckRaycast();
        }

        public bool CheckRaycast()
        {
            var ray = new Ray(_transform.position,
                _transform.forward);
            ray.origin += Vector3.up;
            var res = Points.CheckObjectRaycast(ray, _heroLayerMask);
            return res;
        }
    }
}