using UnityEngine;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Fighter
    {
        private readonly Arch _arch;

        public Fighter(Arch arch)
        {
            _arch = arch;
        }

        public bool HitsEnemy()
        {
            return _arch.HitsEnemy();
        }

        public void TryShoot()
        {
            _arch.TryShoot();
        }
    }
}