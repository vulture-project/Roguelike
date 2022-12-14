using Gameplay.Common.Components;
using Gameplay.Common.States;
using Gameplay.Common.Systems;

using Gameplay.Core.Behaviours;
using Gameplay.Core.States;
using UnityEngine;

namespace Initialization
{
    [RequireComponent(typeof(ComponentOwner), typeof(SystemExecutor))]
    public class WizardInitializer : MonoBehaviour
    {
        [SerializeField]
        private Movement _movement;

        private void Start()
        {
            var componentOwner = gameObject.GetComponent<ComponentOwner>();
            componentOwner.Add(_movement);

            var systemExecutor = gameObject.GetComponent<SystemExecutor>();
            systemExecutor.Add(new AcceleratingSystem());
            systemExecutor.Add(new AnimatingMovementSystem());
            systemExecutor.Add(new MovementInputSystem());
            systemExecutor.Add(new MovementSystem());
            systemExecutor.Add(new OrientatingSystem());
        }
    }
}