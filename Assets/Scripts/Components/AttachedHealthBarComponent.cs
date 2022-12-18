using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public struct AttachedHealthBarComponent
    {
        public HealthBar HealthBar;

        public AttachedHealthBarComponent(HealthBar healthBar)
        {
            HealthBar = healthBar;
        }
    }
}