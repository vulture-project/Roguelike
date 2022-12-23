using UnityEngine;

namespace AI.Common.Aim
{
    public class AimStateMachineConfig
    {
        public AimStateMachineConfig(Transform firePoint, Transform enemy)
        {
            FirePoint = firePoint;
            Enemy = enemy;
        }

        public Transform FirePoint;
        public Transform Enemy;
    }
}