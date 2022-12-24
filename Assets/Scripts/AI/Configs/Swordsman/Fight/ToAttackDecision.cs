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
        private readonly float _enemyRadius;

        private readonly Transform _ownerTransform;

        private readonly LayerMask _heroLayerMask;

        public ToAttackDecision(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;

            // TODO: Handle other types of colliders!
            var enemyCollider = enemy.GetComponent<CapsuleCollider>();
            _enemyRadius = enemyCollider.radius;

            _catch = owner.GetComponent<Catch>();

            _heroLayerMask = LayerMask.GetMask("Hero");
        }

        public override bool Decide()
        {
            Vector3 ownerPosition = _ownerTransform.position;
            Vector3 enemyPosition = _enemyTransform.position;

            // return true;

            return ((enemyPosition - ownerPosition).magnitude <= _catch.Value + _enemyRadius) &&
                   Points.CheckObjectRaycast(new Ray(ownerPosition, _ownerTransform.forward), _heroLayerMask);
            
            // return Points.InOpenBall(ownerPosition, enemyPosition - toEnemy * _enemyRadius, _catch.SqrValue) &&
            //        Points.CheckObjectRaycast(new Ray(ownerPosition, _ownerTransform.forward),
            //            _heroLayerMask);
        }
    }
}