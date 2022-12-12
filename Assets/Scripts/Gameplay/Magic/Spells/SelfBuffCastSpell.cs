using UnityEngine;

namespace Gameplay.Magic.Spells
{
    [CreateAssetMenu(fileName = "SelfBuffCastSpell", menuName = "Self buff cast spell", order = 52)]
    public class SelfBuffCastSpell : ScriptableObject
    {
        [SerializeField]
        private GameObject _selfBuffPrefab;
    }
}