using System;

namespace AI.Common.Events
{
    public class MovementNotifier
    {
        public event EventHandler NeedToComeCloser;

        public void DispatchNeedToComeCloser(object sender, EventArgs args)
        {
            NeedToComeCloser?.Invoke(sender, args);
        }
    }
}