using AI.Base;
using System;
using AI.Configs.Archer.Fight.Stuff;
using System.Diagnostics;

namespace AI.Configs.Archer.Fight
{
    public class AttackAction : AAction
    {
        public AttackAction(Fighter fighter)
        {
            _fighter = fighter;
        }

        public override void Execute()
        {
            if (!_fighter.HitsEnemy())
            {
                OnNeedToComeCloser();
            }
            else
            {
                _fighter.TryShoot();
            }
        }

        public event EventHandler NeedToComeCloser;

        private void OnNeedToComeCloser()
        {
            NeedToComeCloser?.Invoke(this, EventArgs.Empty);
        }

        private readonly Fighter _fighter;
    }
}
