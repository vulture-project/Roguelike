using UnityEngine;

namespace States
{
    [RequireComponent(typeof(Animator))]
    public class SelfBuffCastingState : State
    {
        private Animator _animator;
        private int _castSelfBuffTriggerHash;
        private Transform _transform;        

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _castSelfBuffTriggerHash = Animator.StringToHash("castSelfBuff");
            _transform = transform;
        }

        public override void OnEnter()
        {
            _animator.SetTrigger(_castSelfBuffTriggerHash);
        }
    
        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        public void SelfBuff()
        {
        }

        public void CastingSelfBuffFinished()
        {
            _stateSwitch.SwitchTo<IdleState>();
        }
    }
}