using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Common.Components
{
    [CreateAssetMenu(fileName = "Armour", menuName = "Component/Armour", order = 52)]
    public class Armour : ComponentBase
    {
        public float Value;
    }
}