// // Suppose that we have two different instances of CastingProjectileState, for example for 
// // casting fire blast and casting frost bolt. Firstly we need HUD for book of spells where
// // player can choose which spell his hero will cast. Secondly we need to map player choice
// // to state behaviour. How do it?
//
// // Obviously, we need a storage for available spells. Also we need a storage for current
// // choices.
//
// // Player hit 'B' button, after that state transits to ChoosingSpellState where choose
// // happens.
//
// // StateSwitch
//
// // Idle to
// // AttackState
// // ItemUsageState
//
// // How to change state
//
// // Switch states using StateType
// // Tag 'PrimaryAttack'
// // Tag 'SecondaryAttack'
// // 
// // Tag is an empty class
// // Or we can simply create an enumeration with types
// // But it is not extensible
// // But this solution easily replaced by way type generation
//
// using UnityEngine;
// using System.Collections.Generic;
//
// namespace Impl
// {
//     public enum StateType
//     {
//         None,
//         Idle,
//         PrimaryAttack,
//         SecondaryAttack,
//         FirstItemUsage,
//         SecondItemUsage,
//         ThirdItemUsage,
//         FourthItemUsage,
//         InventoryView,
//         StashView
//     }
//     public interface IStateSwitch
//     {
//         public void Switch(StateType type);
//
//         public void SetTag(State state, StateType type);
//
//         public void AddState(State state);
//
//         public void RemoveState(State state);
//     }
//
//     public abstract class State : MonoBehaviour
//     {
//         protected StateType _type;
//         protected IStateSwitch _stateSwitch;
//
//         public StateType Type()
//         {
//             return _type;
//         }
//
//         public void SetType(StateType type)
//         {
//             _type = type;
//         }
//         
//         public void OnAdd(IStateSwitch stateSwitch)
//         {
//             _stateSwitch = stateSwitch;
//         }
//
//         public void OnRemove(IStateSwitch stateSwitch)
//         {
//             _stateSwitch = null;
//         }
//         
//         public abstract void OnEnter();
//     
//         public abstract void OnUpdate();
//
//         public abstract void OnExit();
//     }
//
//     public class StateSwitch : MonoBehaviour, IStateSwitch
//     {
//         private List<State> _states;
//         private State _state;
//
//         public void Switch(StateType type)
//         {
//             Assert.IsTrue(_states.Exists(state => state.Type() == type));
//             _state = _states.Find(state => state.Type() == type);
//         }
//
//         public void SetTag(State state, StateType type)
//         {
//             if (_states.Exists(state => state.Type() == type))
//             {
//                 
//             }
//         }
//
//         public void AddState(State state)
//         {
//             Assert.IsFalse(_states.Contains(state));
//             _states.Add(state);
//             state.OnAdd(this);
//         }
//
//         public void RemoveState(State state)
//         {
//             Assert.IsTrue(_states.Contains(state));
//             state.OnRemove(this);
//             _states.Remove(state);
//         }
//     }
//     
//     
//     
//     
// }
//
