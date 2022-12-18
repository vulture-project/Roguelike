using UnityEngine;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Fighter
    {
        private readonly Arch _arch;
        private Transform _enemyTransform;

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
    }
}