using Utils.Time;

namespace AI.Base
{
    public class TimeoutDecision : ADecision
    {
        public TimeoutDecision(CountdownTimer timer)
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