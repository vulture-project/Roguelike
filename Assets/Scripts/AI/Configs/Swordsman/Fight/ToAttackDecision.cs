using UnityEngine;
using AI.Base;
using Utils.Math;
using AI.Common.Components;

namespace AI.Configs.Swordsman.Fight
{
    public class ToAttackDecision : ADecision
    {
        public ToAttackDecision(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;

            _catch = owner.GetComponent<Catch>();
        }

        public override bool Decide()
        {
            return Points.InOpenBall(_ownerTransform.position, _enemyTransform.position,
                                     _catch.SqrValue) &&
                   Points.CheckObjectRaycast<PlayerTag>(new Ray(_ownerTransform.position,
                                                                   _ownerTransform.forward));
        }

        private readonly Transform _ownerTransform;
        private readonly Transform _enemyTransform;

        private readonly Catch _catch;
    }
}