using AI.Common.Aim;
using AI.Common.Roam;
using AI.Configs.Archer.Fight;

namespace AI.Configs.Archer
{
    public class MasterStateMachineConfig
    {
        public RoamStateMachineConfig RoamStateMachineConfig;
        public FightStateMachineConfig FightStateMachineConfig;
        public AimStateMachineConfig AimStateMachineConfig;

        public MasterStateMachineConfig(RoamStateMachineConfig roamStateMachineConfig,
                                        FightStateMachineConfig fightStateMachineConfig,
                                        AimStateMachineConfig aimStateMachineConfig)
        {
            RoamStateMachineConfig = roamStateMachineConfig;
            FightStateMachineConfig = fightStateMachineConfig;
            AimStateMachineConfig = aimStateMachineConfig;
        }
    }
}