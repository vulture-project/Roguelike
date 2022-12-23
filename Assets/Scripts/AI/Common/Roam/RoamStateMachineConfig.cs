using Utils.Math;

namespace AI.Common.Roam
{
    public class RoamStateMachineConfig
    {
        public RoamStateMachineConfig(Range stayTime, Range roamDistance)
        {
            StayTime = stayTime;
            RoamDistance = roamDistance;
        }

        public Range StayTime;
        public Range RoamDistance;
    }
}