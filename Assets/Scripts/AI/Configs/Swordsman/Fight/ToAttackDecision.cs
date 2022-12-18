using AI.Base;
using AI.Common.Components;
using UnityEngine;
using Utils.Math;

namespace AI.Configs.Swordsman.Fight
{
    public class ToAttackDecision : ADecision
    {
        private readonly Catch _catch;
        private readonly Transform _enemyTransform;

        private readonly Transform _ownerTransform;

        private readonly LayerMask _heroLayerMask;

        public ToAttackDecision(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;

            _catch = owner.GetComponent<Catch>();

            _heroLayerMask = LayerMask.GetMask("Hero");
        }

        public override bool Decide()
        {
            return Points.InOpenBall(_ownerTransform.position, _enemyTransform.position, _catch.SqrValue) &&
                   Points.CheckObjectRaycast(new Ray(_ownerTransform.position, _ownerTransform.forward),
                       _heroLayerMask);
        }
    }
}