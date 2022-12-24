using AI.Base;
using UnityEngine;

namespace AI.Common.Aim
{
    public class AimAction : AAction
    {
        public AimAction(Transform firePoint, Transform enemy)
        {
            _firePoint = firePoint;
            _enemy = enemy;
        }

        public override void Execute()
        {
            _firePoint.LookAt(_enemy);
        }

        private readonly Transform _firePoint;
        private readonly Transform _enemy;
    }
}