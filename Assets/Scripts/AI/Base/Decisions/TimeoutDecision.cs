using Utils.Time;

namespace AI.Base
{
    public class TimeoutDecision : ADecision
    {
        private readonly CountdownTimer _timer;

        public TimeoutDecision(CountdownTimer timer)
        {
            _timer = timer;
        }

        public override bool Decide()
        {
            return _timer.IsDown();
        }
    }
}