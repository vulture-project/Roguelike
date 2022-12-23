using AI.Base;
using Utils.Time;

namespace AI.Common.Roam
{
    internal class StayToFollowDecision : ADecision
    {
        private readonly CountdownTimer _timer;

        public StayToFollowDecision(CountdownTimer timer)
        {
            _timer = timer;
        }

        public override bool Decide()
        {
            return _timer.IsDown();
        }
    }
}