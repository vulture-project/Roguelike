using System.Collections.Generic;

namespace AI.Base
{
    public class State
    {
        private readonly List<AAction> _actions;
        private readonly List<Transition> _transitions;

        public State()
        {
            _actions = new List<AAction>();
            _transitions = new List<Transition>();
        }

        public void AddAction(AAction aAction)
        {
            _actions.Add(aAction);
        }

        public void AddTransition(Transition transition)
        {
            _transitions.Insert(0, transition);
        }

        public void OnEnter()
        {
            foreach (var action in _actions)
                action.OnEnter();
        }

        public void Execute(StateMachine stateMachine)
        {
            foreach (var action in _actions)
                action.Execute();

            foreach (var transition in _transitions)
                if (transition.Transit(stateMachine))
                    break;
        }

        public void OnExit()
        {
            foreach (var action in _actions)
                action.OnExit();
        }
    }
}