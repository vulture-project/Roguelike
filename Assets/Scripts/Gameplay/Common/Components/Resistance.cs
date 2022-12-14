using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Common.Components
{
    [CreateAssetMenu(fileName = "Resistance", menuName = "Component/Resistance", order = 53)]
    public class Resistance : ComponentBase
    {
        public float Physical;
        
        public float Fire;
        
        public float Ice;

        public float Magic;
    }
}