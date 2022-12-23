using AI.Base;
using UnityEngine;

namespace AI.Common.Watch
{
    public class WatchAction : AAction
    {
        private readonly Transform _enemyTransform;

        private readonly Transform _ownerTransform;

        public WatchAction(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;
        }

        public override void Execute()
        {
            _ownerTransform.LookAt(_enemyTransform);
        }
    }
}