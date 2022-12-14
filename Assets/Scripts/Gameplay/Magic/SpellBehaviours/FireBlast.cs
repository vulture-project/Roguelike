using UnityEngine;

namespace Gameplay.Magic.SpellBehaviours
{
    public class FireBlast : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}