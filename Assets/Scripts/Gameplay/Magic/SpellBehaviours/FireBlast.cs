using Components;
using UnityEngine;

namespace Spells
{
    public class FireBlast : MonoBehaviour
    {
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private float damage;
        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage);
            }
            // Instantiate(impactPrefab, collision.contacts[0].point, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}