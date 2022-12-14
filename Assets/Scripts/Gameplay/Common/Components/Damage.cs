using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Common.Components
{
    [CreateAssetMenu(fileName = "Damage", menuName = "Component/Damage", order = 52)]
    public class Damage : ComponentBase
    {
        public float Value;
    }
}