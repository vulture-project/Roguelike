using Components;
using UnityEngine;

namespace BackgroundActions
{
    public class AnimatingMovementAction : MonoBehaviour
    {
        private Animator _animator;
        private int _velocityXHash;
        private int _velocityZHash;
        private Movement _movement;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _velocityXHash = Animator.StringToHash("velocityX");
            _velocityZHash = Animator.StringToHash("velocityZ");
            _movement = gameObject.GetComponent<Movement>();
        }

        private void Update()
        {
            _animator.SetFloat(_velocityXHash, _movement.Velocity.x);
            _animator.SetFloat(_velocityZHash, _movement.Velocity.z);
        }
    }
}