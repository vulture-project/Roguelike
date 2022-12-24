using UnityEngine;

namespace Prefabs
{
    [CreateAssetMenu(fileName = "SelfBuff", menuName = "Spell/SelfBuff", order = 54)]
    public class SelfBuff : ScriptableObject
    {
        public GameObject Prefab;
    }
}