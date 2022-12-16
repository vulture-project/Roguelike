using UnityEngine;
using Utils.Math;
using AI.Base;
using AI.Common.Roam;

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

        public State ExitState { get; private set; }
    }
}