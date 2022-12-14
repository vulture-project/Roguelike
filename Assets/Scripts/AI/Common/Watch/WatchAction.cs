using UnityEngine;
using AI.Base;

namespace AI.Common.Watch
{
    public class WatchAction : AAction
    {
        public WatchAction(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;
        }

        public override void Execute()
        {
            _ownerTransform.LookAt(_enemyTransform);
        }

        private readonly Transform _ownerTransform;
        private readonly Transform _enemyTransform;
    }
}
