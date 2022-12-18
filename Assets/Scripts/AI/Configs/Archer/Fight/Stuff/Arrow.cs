using UnityEngine;

namespace AI.Configs.Archer.Fight.Stuff
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemy;
        // private Health _enemyHealth;

        private float _damage = 50.0f;
        private readonly float _speed = 15.0f;

        private void Awake()
        {
            // _enemyHealth = enemy.GetComponent<Health>();
        }

        private void Update()
        {
            Move();
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

        private void Move()
        {
            transform.position += _speed * transform.forward * Time.deltaTime;
        }
    }
}