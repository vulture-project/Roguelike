using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "SelfBuff", menuName = "Spell/SelfBuff", order = 54)]
    public class SelfBuffCastSpell : ScriptableObject
    {
        public GameObject Prefab;
    }
}