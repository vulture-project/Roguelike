using System.Collections.Generic;
using States;
using UnityEngine;
using UnityEngine.Assertions;

namespace UnityComponents
{
    public class StateSwitch : MonoBehaviour, IStateSwitch
    {
        [SerializeField]
        private List<State> _states;

        [SerializeField]
        private State _state;

        private void Start()
        {
            foreach (var state in _states) state.SetStateSwitch(this);
        }

        private void Update()
        {
            _state.OnUpdate();
        }

        public void SwitchTo<TState>() where TState : State
        {
            Assert.IsTrue(_states.Exists(state => state is TState));

            _state.OnExit();
            _state = _states.Find(state => state is TState);
            _state.OnEnter();
        }

        public void SwitchTo(State state)
        {
            Assert.IsTrue(_states.Contains(state));

            _state.OnExit();
            _state = state;
            _state.OnEnter();
        }
    }
}