using AI.Base;
using AI.Interaction;
using UnityEngine;

namespace AI.Common.Watch
{
    public class WatchStateMachine : StateMachine
    {
        public WatchStateMachine(GameObject agent, GameObject enemy,
                                 SpottingManager spottingManager)
        {
            _agent = agent;
            _enemy = enemy;
            BuildIdleState();
            BuildWatchState();
            BuildIdleToWatchTransition(spottingManager);
            BuildWatchToIdleTransition();
        }

        public State IdleState { get; private set; }
        public State WatchState { get; private set; }
        public ToWatchDecision ToWatchDecision { get; private set; }

        private void BuildIdleState()
        {
            IdleState = new State();
            AddStateToList(IdleState);
            EntryState = IdleState;
        }

        private void BuildWatchState()
        {
            WatchState = new State();
            var watchAction = new WatchAction(_agent, _enemy);
            WatchState.AddAction(watchAction);
            AddStateToList(WatchState);
        }

        private void BuildIdleToWatchTransition(SpottingManager spottingManager)
        {
            ToWatchDecision = new ToWatchDecision(_agent, _enemy, spottingManager);
            var toWatchTransition = new Transition(ToWatchDecision, WatchState);
            IdleState.AddTransition(toWatchTransition);
        }

        private void BuildWatchToIdleTransition()
        {
            var toIdleTransition = new Transition(new OppositeDecision(
                                                        new ToWatchDecisionCore(_agent, _enemy)),
                                                  IdleState);
            WatchState.AddTransition(toIdleTransition);
        }

        private readonly GameObject _agent;
        private readonly GameObject _enemy;
    } 
}
