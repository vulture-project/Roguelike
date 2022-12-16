using UnityEngine;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Arrow : MonoBehaviour
    {
        private void Awake()
        {
            // _enemyHealth = enemy.GetComponent<Health>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += _speed * transform.forward * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            var otherGameObject = other.gameObject;
            if (otherGameObject.GetComponent<PlayerTag>() != null)
            {
                // otherGameObject.GetComponent<Health>().TakeArchDamage(_damage);
            }
            Destroy(gameObject);
        }

        [SerializeField] private GameObject enemy;
        // private Health _enemyHealth;

        private float _damage = 50.0f;
        private float _speed = 15.0f;
    }
}