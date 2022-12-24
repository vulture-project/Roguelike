using AI.Common.Roam;
using Utils.Math;

namespace AI.Common.Dodge
{
    public class DodgeStateMachineConfig : RoamStateMachineConfig
    {
        public Range DodgeTime;

        public DodgeStateMachineConfig(RoamStateMachineConfig roamConfig, Range dodgeTime) :
            base(roamConfig.StayTime, roamConfig.RoamDistance)
        {
            DodgeTime = dodgeTime;
        }
    }
}