using AI.Base;
using UnityEngine;
using Utils.Math;

namespace AI.Common.Watch
{
    public class ToWatchDecisionCore : ADecision
    {
        private readonly Transform _enemyTransform;

        private readonly Transform _ownerTransform;

        private readonly FieldOfView _ownerWatchDistance;

        private readonly LayerMask _heroLayerMask;

        public ToWatchDecisionCore(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;

            _ownerWatchDistance = owner.GetComponent<FieldOfView>();

            _heroLayerMask = LayerMask.GetMask("Hero");
        }

        public override bool Decide()
        {
            return CheckRadius() && CheckRays();
        }

        public bool CheckRadius()
        {
            return Points.InOpenBall(_ownerTransform.position,
                _enemyTransform.position,
                _ownerWatchDistance.SqrValue);
        }

        public bool CheckRays()
        {
            var ray = new Ray(_ownerTransform.position + Vector3.up,
                _enemyTransform.position - _ownerTransform.position);
            Debug.Log(ray);
            Debug.DrawRay(ray.origin, ray.direction * 4);
            return Points.CheckObjectRaycast(ray, _heroLayerMask);
        }
    }
}