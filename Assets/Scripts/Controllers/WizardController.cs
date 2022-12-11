using States;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{

public class WizardController : MonoBehaviour, IStateSwitch
{
    private State _state;
    private List<State> _states;
    private void Start()
    {
        _state = gameObject.GetComponent<MovementState>();
        _states = new List<State>()
        {
            gameObject.GetComponent<CastingProjectileState>(),
            gameObject.GetComponent<CastingSelfBuffState>(),
            gameObject.GetComponent<MovementState>()
        };
        foreach (var state in _states)
        {
            state.OnStart(this);
        }
    }
    private void Update()
    {
        _state.OnUpdate();
    }
    public void SwitchTo<TState>() where TState : State
    {
        _state.OnExit();
        _state = _states.Find(state => state is TState);
        _state.OnEnter();
    }
}

}