using AI.Common.Chase;
using AI.Common.Dodge;
using UnityEngine;

namespace AI.Configs.Archer.Fight
{
    public class FightStateMachineConfig
    {
        public DodgeStateMachineConfig DodgeStateMachineConfig;
        public TimeoutChaseStateMachineConfig TimeoutChaseStateMachineConfig;

        public Transform FirePoint;
        public float ReloadTime;
        public float ProjectileWidth;

        public FightStateMachineConfig(DodgeStateMachineConfig dodgeStateMachineConfig,
                                       TimeoutChaseStateMachineConfig timeoutChaseStateMachineConfig,
                                       Transform firePoint, float reloadTime, float projectileWidth)
        {
            DodgeStateMachineConfig = dodgeStateMachineConfig;
            TimeoutChaseStateMachineConfig = timeoutChaseStateMachineConfig;
            FirePoint = firePoint;
            ReloadTime = reloadTime;
            ProjectileWidth = projectileWidth;
        }
    }
}