using System;

namespace AI.Base
{
    public class Transition
    {
        public Transition(ADecision decision, State trueState)
        {
            _decision = decision;
            TrueState = trueState;
        }

        public Transition(ADecision decision, Transition forwardTransition)
        {
            _decision = decision;
            forwardTransition.Accepted += SwitchToSourceState;
        }

        public Transition(Transition other)
        {
            _decision = other._decision;
            TrueState = other.TrueState;
        }

        public bool Transit(StateMachine stateMachine)
        {
            if (_decision.Decide())
            {
                var srcState = stateMachine.CurrentState;
                stateMachine.CurrentState = TrueState;
                OnAccepted(srcState, TrueState);
                return true;
            }
            return false;
        }

        public event EventHandler<TransitionAcceptedArgs> Accepted;

        public void OnAccepted(State srcState, State dstState)
        {
            Accepted?.Invoke(this, new TransitionAcceptedArgs(srcState, dstState));
        }

        public void SwitchToSourceState(object sender, TransitionAcceptedArgs args)
        {
            TrueState = args.SrcState;
        }

        public State TrueState { get; private set; }

        private ADecision _decision;
    }
}
