using Gameplay.Core.Components;

using UnityEngine;

namespace Gameplay.Magic.SpellBehaviours
{
    public class FireBlast : MonoBehaviour
    {
        [SerializeField]
        private float damage;
        
        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage);
            }
            Destroy(gameObject);
        }
    }
}