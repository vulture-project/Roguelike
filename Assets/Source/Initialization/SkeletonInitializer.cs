using Gameplay.Common.Systems;

using Gameplay.Core.Behaviours;

using UnityEngine;

namespace Initialization
{
    [RequireComponent(typeof(ComponentOwner), typeof(SystemExecutor))]
    public class SkeletonInitializer : MonoBehaviour
    {
        private void Start()
        {
            var systemExecutor = gameObject.GetComponent<SystemExecutor>();
            systemExecutor.Add(new DamageSystem());
            systemExecutor.Add(new DeathChecker());
        }
    }
}