using Gameplay.Core.States;

using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Common.States
{
    public class StateSwitch : MonoBehaviour, IStateSwitch
    {
        [SerializeField]
        private List<State> _states;
        
        [SerializeField]
        private State _state;
        
        private void Awake()
        {
            foreach (var state in _states)
            {
                state.SetStateSwitch(this);
            }
        }

        private void Update()
        {
            _state.OnUpdate();
        }
        
        public void Switch(StateType type)
        {
            if (_states.Exists(state => state.Type() == type))
            {
                _state.OnExit();
                _state = _states.Find(state => state.Type() == type);
                _state.OnEnter();
            }
        }

        public void Add(State state)
        {
            state.OnAdd(this);
            _states.Add(state);
        }

        public void Remove(State state)
        {
            _states.Remove(state);
            state.OnRemove();
        }
    }
}