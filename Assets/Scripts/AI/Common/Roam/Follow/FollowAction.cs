﻿using AI.Base;
using UnityEngine;
using UnityEngine.AI;
using Utils.Math;

namespace AI.Common.Roam
{
    internal class FollowAction : AGameObjectBasedAction
    {
        private readonly Range _distance;

        private readonly NavMeshAgent _navMeshAgent;

        public FollowAction(GameObject gameObject, Range distance) :
            base(gameObject)
        {
            _distance = distance;
            _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        public override void OnEnter()
        {
            var currPos = _navMeshAgent.transform.position;
            var randomVector = GetRandomVector();
            _navMeshAgent.SetDestination(currPos + randomVector);
            if (_navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
                _navMeshAgent.SetDestination(currPos - randomVector);
        }

        public override void OnExit()
        {
            _navMeshAgent.destination = _navMeshAgent.transform.position;
        }

        private Vector3 GetRandomVector()
        {
            var angle = Random.Range(0.0f, 360.0f);
            var dir = Quaternion.AngleAxis(angle, Vector3.up)
                      * Vector3.forward;
            return dir * Random.Range(_distance.left, _distance.right);
        }
    }
}