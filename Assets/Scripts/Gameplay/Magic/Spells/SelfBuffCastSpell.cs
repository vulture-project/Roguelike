using UnityEngine;

namespace Gameplay.Magic.Spells
{
    [CreateAssetMenu(fileName = "SelfBuffCastSpell", menuName = "Spell/Self buff", order = 52)]
    public class SelfBuffCastSpell : ScriptableObject
    {
        [SerializeField]
        private GameObject _selfBuffPrefab;

        public GameObject SelfBuffPrefab()
        {
            return _selfBuffPrefab;
        }
    }
}