using System.Collections.Generic;
using Utils.Time;
using Utils.Math;

namespace AI.Base
{
    public class StateMachine
    {
        public StateMachine()
        {
            _states = new List<State>();
        }
        
        public void AddStateToList(State state)
        {
            _states.Add(state);
        }

        public State EntryState { get; set; }
        public State CurrentState
        {
            get => _currentState;
            set
            {
                _currentState?.OnExit();
                _currentState = value;
                _currentState.OnEnter();
            }
        }

        public virtual void OnEntry()
        {
            CurrentState = EntryState;
            CurrentState.OnEnter();
        }

        public virtual void Execute()
        {
            CurrentState.Execute(this);
        }

        public virtual void OnExit()
        {
            CurrentState.OnExit();
        }

        public void AddTransitionToAllStates(Transition transition)
        {
            foreach (var state in _states)
                state.AddTransition(transition);
        }

        public void AddActionToAllStates(AAction action)
        {
            foreach (var state in _states)
                state.AddAction(action);
        }

        public State MakeTimeout(Range timeout)
        {
            var newEntryState = new State();
            var timer = new CountdownTimer();
            var restartTimerAction = new RestartTimerAction(timer, timeout);

            newEntryState.AddAction(restartTimerAction);
            newEntryState.AddTransition(new Transition(new TrueDecision(), EntryState));

            var exitState = new State();
            AddTransitionToAllStates(new Transition(new TimeoutDecision(timer), exitState));

            EntryState = newEntryState;
            AddStateToList(EntryState);

            return exitState;
        }

        protected static void MergeCore(StateMachine result, StateMachine operand)
        {
             foreach (var state in operand._states)
                result.AddStateToList(state);           
        }

        protected readonly List<State> _states;
        protected State _currentState = null;
    }
}
