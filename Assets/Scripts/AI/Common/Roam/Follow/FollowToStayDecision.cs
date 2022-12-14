using AI.Base;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Common.Roam
{
    public class FollowToStayDecision : AGameObjectBasedDecision
    {
        public FollowToStayDecision(GameObject gameObject, float eps) :
            base(gameObject)
        {
            _sqrEps = eps * eps;
            _eps = eps;
            _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        public override bool Decide()
        {
            return _navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
                   _navMeshAgent.pathStatus == NavMeshPathStatus.PathPartial ||
                   _navMeshAgent.remainingDistance <= _eps;
        }

        private float _sqrEps;
        private float _eps;
        private NavMeshAgent _navMeshAgent;
    }
}