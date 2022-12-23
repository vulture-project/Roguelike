using UnityEngine;

namespace Components
{
    public struct SpellImpactComponent
    {
        public readonly GameObject ImpactPrefab;

        public SpellImpactComponent(GameObject impactPrefab)
        {
            ImpactPrefab = impactPrefab;
        }
    }
}