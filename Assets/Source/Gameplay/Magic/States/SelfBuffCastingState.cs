using Gameplay.Core.States;

using Gameplay.Magic.Spells;

using UnityEngine;

namespace Gameplay.Magic.States
{
    [RequireComponent(typeof(Animator))]
    public class SelfBuffCastingState : State
    {
        [SerializeField]
        private SelfBuffCastSpell _spell; 

        private Animator _animator;
        private int _isCastingSelfBuffHash;
        private Transform _transform;        

        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
            _isCastingSelfBuffHash = Animator.StringToHash("isCastingSelfBuff");
            _transform = transform;
        }

        public override void OnEnter()
        {
            _animator.SetBool(_isCastingSelfBuffHash, true);
        }
    
        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            _animator.SetBool(_isCastingSelfBuffHash, false);
        }

        public void SelfBuff()
        {
        }

        public void SelfBuffCastingFinished()
        {
            _stateSwitch.Switch(StateType.Idle);
        }
    }
}