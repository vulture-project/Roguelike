using UnityEngine;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Fighter
    {
        public Fighter(Arch arch, GameObject enemy)
        {
            _arch = arch;
            _enemyTransform = enemy.transform;
        }

        public bool HitsEnemy()
        {
            return _arch.HitsEnemy();
        }

        public void TryShoot()
        {
            _arch.TryShoot();
        }

        private Arch _arch;
        private Transform _enemyTransform;
    }
}
