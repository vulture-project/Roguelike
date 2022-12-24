using AI.Base;
using AI.Common.Roam;
using UnityEngine;

namespace AI.Common.Dodge
{
    public class DodgeStateMachine : RoamStateMachine
    {
        public DodgeStateMachine(GameObject agent, DodgeStateMachineConfig config) :
            base(agent, config)
        {
            ExitState = MakeTimeout(config.DodgeTime);
        }

        public State ExitState { get; private set; }
    }
}