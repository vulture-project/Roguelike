using AI.Base;
using UnityEngine;
using Utils.Math;
using Utils.Time;

namespace AI.Common.Roam
{
    public class RoamStateMachine : StateMachine
    {
        private readonly GameObject _agent;

        private CountdownTimer _timer;

        public RoamStateMachine(GameObject agent, Range stayTime,
            Range roamDistance)
        {
            _agent = agent;
            BuildStayState(stayTime);
            BuildFollowState(roamDistance);
            BuildFollowToStayTransition();
            BuildStayToFollowTransition();
        }

        public State StayState { get; private set; }
        public State FollowState { get; private set; }

        private void BuildStayState(Range stayTime)
        {
            StayState = new State();
            _timer = new CountdownTimer();
            var stayAction = new StayAction(_agent, _timer, stayTime);
            StayState.AddAction(stayAction);
            AddStateToList(StayState);
            EntryState = StayState;
        }

        private void BuildFollowState(Range roamDistance)
        {
            FollowState = new State();
            var followAction = new FollowAction(_agent, roamDistance);
            FollowState.AddAction(followAction);
            AddStateToList(FollowState);
        }

        private void BuildStayToFollowTransition()
        {
            var stayToFollowDecision = new StayToFollowDecision(_timer);
            var stayToFollowTransition = new Transition(stayToFollowDecision,
                FollowState);
            StayState.AddTransition(stayToFollowTransition);
        }

        private void BuildFollowToStayTransition()
        {
            var followToStayDecision = new FollowToStayDecision(_agent, 0.01f);
            var followToStayTransition = new Transition(followToStayDecision,
                StayState);
            FollowState.AddTransition(followToStayTransition);
        }
    }
}