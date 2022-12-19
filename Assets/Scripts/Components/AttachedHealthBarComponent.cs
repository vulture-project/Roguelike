using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public struct AttachedHealthBarComponent
    {
        public Bar HealthBar;

        public AttachedHealthBarComponent(Bar healthBar)
        {
            HealthBar = healthBar;
        }
    }
}