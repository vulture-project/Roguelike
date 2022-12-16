using System;

namespace AI.Base
{
    public class TransitionAcceptedArgs : EventArgs
    {
        public TransitionAcceptedArgs(State srcState,
                                      State dstState)
        {
            SrcState = srcState;
            DstState = dstState;
        }

        public State SrcState;
        public State DstState;
    }
}