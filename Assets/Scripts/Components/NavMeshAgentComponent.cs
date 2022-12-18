using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public struct NavMeshAgentComponent
    {
        public readonly NavMeshAgent NavMeshAgent;

        public NavMeshAgentComponent(NavMeshAgent navMeshAgent)
        {
            NavMeshAgent = navMeshAgent;
        }
    }
}
