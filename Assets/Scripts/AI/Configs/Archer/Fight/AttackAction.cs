using System;
using AI.Base;
using AI.Configs.Archer.Fight.Stuff;
using UnityEngine;

namespace AI.Configs.Archer.Fight
{
    public class AttackAction : AAction
    {
        private readonly Fighter _fighter;

        public AttackAction(Fighter fighter)
        {
            _fighter = fighter;
        }

        public override void Execute()
        {
            if (!_fighter.HitsEnemy())
                OnNeedToComeCloser();
            else
                _fighter.TryShoot();
        }

        public event EventHandler NeedToComeCloser;

        private void OnNeedToComeCloser()
        {
            Debug.Log("need to come closer in fighter");
            NeedToComeCloser?.Invoke(this, EventArgs.Empty);
        }
    }
}