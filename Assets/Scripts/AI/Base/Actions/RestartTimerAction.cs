using UnityEngine;
using Utils.Math;
using Utils.Time;

namespace AI.Base
{
    public class RestartTimerAction : AAction
    {
        public RestartTimerAction(CountdownTimer timer, Range timeRange)
        {
            _timer = timer;
            _timeRange = timeRange;
        }

        public override void OnEnter()
        {
            _timer.Restart(Random.Range(_timeRange.left, _timeRange.right));
        }

        private CountdownTimer _timer;
        private Range _timeRange;
    }
}