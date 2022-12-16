using UnityEngine;
using Utils.Time;
using Utils.Math;

namespace AI.Configs.Swordsman.Fight.Stuff
{
    public class Fighter
    {
        public Fighter(GameObject owner, GameObject enemy, float reloadTime)
        {
            _transform = owner.transform;

            _animator = owner.GetComponent<Animator>();
            _attackHash = Animator.StringToHash("attack");
            
            _enemy = enemy;

            _sword = owner.GetComponent<Sword>();
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
            Debug.DrawRay(ray.origin, ray.direction);
            ray.origin += Vector3.up;
            var res = Points.CheckObjectRaycast<PlayerTag>(ray);
            Debug.Log("check raycast result: " + res);
            return res;
        }

        private Transform _transform;

        private GameObject _enemy;

        private Animator _animator;
        private int _attackHash;
        
        private Transform _enemyTransform;

        private Sword _sword;
        private float _reloadTime;
        private CountdownTimer _timer;
    }
}
