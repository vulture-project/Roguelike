using Gameplay.Common.Systems;

using Gameplay.Core.Behaviours;

using UnityEngine;

namespace Initialization
{
    [RequireComponent(typeof(ComponentOwner), typeof(SystemExecutor))]
    public class WizardInitializer : MonoBehaviour
    {
        private void Start()
        {
            var systemExecutor = gameObject.GetComponent<SystemExecutor>();
            systemExecutor.Add(new AcceleratingSystem());
            systemExecutor.Add(new AnimatingMovementSystem());
            systemExecutor.Add(new MovementInputSystem());
            systemExecutor.Add(new MovementSystem());
            systemExecutor.Add(new OrientatingSystem());
            systemExecutor.Add(new DamageSystem());
        }
    }
}