using Utils.Math;

namespace AI.Common.Chase
{
    public class TimeoutChaseStateMachineConfig 
    {
        public Range Timeout; 

        public TimeoutChaseStateMachineConfig(Range timeout)
        {
            Timeout = timeout;
        }
    }
}