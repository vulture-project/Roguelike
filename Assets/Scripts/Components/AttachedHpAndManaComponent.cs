using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public struct AttachedHpAndManaComponent
    {
        public BarWithoutRotation HealthBar;
        public BarWithoutRotation ManaBar;

        public AttachedHpAndManaComponent(BarWithoutRotation healthBar, BarWithoutRotation manaBar)
        {
            HealthBar = healthBar;
            ManaBar = manaBar;
        }
    }
}