using AI.Base;
using AI.Configs.Swordsman.Fight.Stuff;

namespace AI.Configs.Swordsman.Fight
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
            _fighter.TryHit();
        }
    }
}