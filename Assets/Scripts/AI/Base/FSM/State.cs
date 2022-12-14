using System.Collections.Generic;

namespace AI.Base
{
    public class State
    {
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
            _transitions.Add(transition);
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

        private List<AAction> _actions;
        private List<Transition> _transitions;
    }
}
