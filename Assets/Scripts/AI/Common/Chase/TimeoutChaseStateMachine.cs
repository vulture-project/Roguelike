using AI.Base;
using AI.Common.Events;
using UnityEngine;
using Utils.Math;

namespace AI.Common.Chase
{
    public class TimeoutChaseStateMachine : ChaseStateMachine
    {
        public TimeoutChaseStateMachine(GameObject agent, GameObject enemy,
            MovementNotifier movementNotifier,
            Range timeout) :
            base(agent, enemy, movementNotifier)
        {
            ExitState = MakeTimeout(timeout);
        }

        public State ExitState { get; }
    }
}