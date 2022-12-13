using System;
using Gameplay.Core.States;

using System.Collections.Generic;

using UnityEngine;

namespace Player.Controllers
{
    public class WizardController : MonoBehaviour, IStateMachine
    {
        private List<State> _states;
        private State _state;

        private void Update()
        {
            _state.OnUpdate();
        }

        public void Switch(StateType type)
        {
            _state.OnExit();
            _state = _states.Find(state => state.Type() == type);
            _state.OnEnter();
        }

        public void SetType(State state, StateType type)
        {
            if (_states.Exists(state => state.Type() == type))
            {
                _states.Find(state => state.Type() == type).SetType(StateType.None);
            }
            state.SetType(type);
        }

        public void AddState(State state)
        {
            _states.Add(state);
            state.OnAdd(this);
        }

        public void RemoveState(State state)
        {
            state.OnRemove(this);
            _states.Remove(state);
        }
    }
}