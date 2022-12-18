using AI.Base;
using UnityEngine;
using UnityEngine.AI;
using Utils.Math;

namespace AI.Common.Chase
{
    public class ChaseAction : AGameObjectBasedAction
    {
        private readonly GameObject _chased;

        private readonly NavMeshAgent _navMeshAgent;

        private float _rebuildPathDist;
        private readonly float _sqrRebuildPathDist;

        public ChaseAction(GameObject owner, GameObject chased,
            float rebuildPathDist) : base(owner)
        {
            _navMeshAgent = owner.GetComponent<NavMeshAgent>();
            _chased = chased;

            _rebuildPathDist = rebuildPathDist;
            _sqrRebuildPathDist = rebuildPathDist * rebuildPathDist;
        }

        public override void OnEnter()
        {
            SetDestinationToChased();
        }

        public override void Execute()
        {
            if (NeedToChangePath())
                SetDestinationToChased();
        }

        public override void OnExit()
        {
            _navMeshAgent.destination = _navMeshAgent.transform.position;
        }

        private bool NeedToChangePath()
        {
            return !Points.InOpenBall(_chased.transform.position,
                _navMeshAgent.destination,
                _sqrRebuildPathDist);
        }

        private void SetDestinationToChased()
        {
            _navMeshAgent.destination = _chased.transform.position;
        }
    }
}