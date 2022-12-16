using UnityEngine;
using AI.Base;
using Utils.Math;
using AI.Common.Events;

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

        public State ExitState { get; private set; }
     }
}