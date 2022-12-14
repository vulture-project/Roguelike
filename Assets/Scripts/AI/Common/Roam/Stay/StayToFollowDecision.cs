using AI.Base;
using UnityEngine;
using Utils.Time;

namespace AI.Common.Roam
{
    class StayToFollowDecision : ADecision
    {
        public StayToFollowDecision(CountdownTimer timer)
        {
            _timer = timer;
        }

        public override bool Decide()
        {
            return _timer.IsDown();
        }

        private CountdownTimer _timer;
    }
}
