using AI.Common.Roam;
using AI.Configs.Swordsman.Fight;

namespace AI.Configs.Swordsman
{
    public class MasterStateMachineConfig
    {
        public MasterStateMachineConfig(RoamStateMachineConfig roamStateMachineConfig,
                                        FightStateMachineConfig fightStateMachineConfig)
        {
            RoamStateMachineConfig = roamStateMachineConfig;
            FightStateMachineConfig = fightStateMachineConfig;
        }

        public RoamStateMachineConfig RoamStateMachineConfig;
        public FightStateMachineConfig FightStateMachineConfig;
    }
}