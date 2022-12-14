using AI.Base;
using System;
using UnityEngine;
using Utils.Math;

namespace AI.Common.Watch
{
    public class ToWatchDecisionCore : ADecision
    {
        public ToWatchDecisionCore(GameObject owner, GameObject enemy)
        {
            _ownerTransform = owner.transform;
            _enemyTransform = enemy.transform;

            _ownerWatchDistance = owner.GetComponent<FieldOfView>();
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
                              _enemyTransform.position -
                              _ownerTransform.position);
            Debug.DrawRay(ray.origin, ray.direction);
            return Points.CheckObjectRaycast<PlayerTag>(ray);
        }

        private readonly Transform _ownerTransform;
        private readonly Transform _enemyTransform;

        private readonly FieldOfView _ownerWatchDistance;
    }
}