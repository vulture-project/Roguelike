using Gameplay.Common.Components;

using Gameplay.Core.Behaviours;

using UnityEngine;

namespace Gameplay.Magic.SpellBehaviours
{
    public class FireBlast : MonoBehaviour
    {
        [SerializeField]
        private Damage _damage;
        
        private void OnCollisionEnter(Collision collision)
        {
            TryApplyDamage(collision.gameObject.GetComponent<ComponentOwner>());
            Destroy(gameObject);
        }
        
        private void TryApplyDamage(ComponentOwner componentOwner)
        {
            if (componentOwner == null)
            {
                return;
            }
            if (!componentOwner.Has<Damage>())
            {
                return;
            }
            var damage = componentOwner.Get<Damage>();
            damage.Value += _damage.Value;
        }
    }
}