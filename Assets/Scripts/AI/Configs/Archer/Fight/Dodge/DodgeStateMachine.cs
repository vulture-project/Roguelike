using AI.Base;
using AI.Common.Roam;
using UnityEngine;
using Utils.Math;

namespace AI.Configs.Archer.Fight.Dodge
{
    public class DodgeStateMachine : RoamStateMachine
    {
        public DodgeStateMachine(GameObject agent, Range stayTime,
            Range roamDistance, Range roamTime) :
            base(agent, stayTime, roamDistance)
        {
            ExitState = MakeTimeout(roamTime);
        }

        public State ExitState { get; }
    }
}