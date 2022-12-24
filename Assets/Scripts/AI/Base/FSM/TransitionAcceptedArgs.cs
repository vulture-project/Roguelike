using System;

namespace AI.Base
{
    public class TransitionAcceptedArgs : EventArgs
    {
        public State DstState;

        public State SrcState;

        public TransitionAcceptedArgs(State srcState,
            State dstState)
        {
            SrcState = srcState;
            DstState = dstState;
        }
    }
}