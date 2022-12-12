using Gameplay.Core.States;
using Gameplay.Core.Components;

using Gameplay.Magic.Spells;

using UnityEngine;

namespace Gameplay.Magic.States
{
    [RequireComponent(typeof(Animator), typeof(Mana))]
    public class CastingSelfBuffState : State
    {
        private Animator _animator;
        private int _isCastingSelfBuffHash;
        private Mana _mana;
        private SelfBuffCastSpell _spell;
        private Transform _transform;        

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _isCastingSelfBuffHash = Animator.StringToHash("isCastingSelfBuff");
            _mana = GetComponent<Mana>();
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
            _stateMachine.Switch(StateType.Idle);
        }
    }
}