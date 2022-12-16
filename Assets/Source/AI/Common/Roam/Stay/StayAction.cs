using AI.Base;
using UnityEngine;
using Utils.Math;
using Utils.Time;

namespace AI.Common.Roam
{
    public class StayAction : AGameObjectBasedAction
    {
        public StayAction(GameObject gameObject, CountdownTimer timer,
                          Range stayTime) :
            base(gameObject)
        {
            _stayTime = stayTime;
            _timer = timer;
        }

        public override void OnEnter()
        {
            var dt = Random.Range(_stayTime.left, _stayTime.right);
            _timer.Restart(dt);
        }

        public override void OnExit()
        {
            _timer.Reset();
        }

        private Range _stayTime;

        private CountdownTimer _timer;
    }
}
