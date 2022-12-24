using AI.Base;
using AI.Common.Events;
using UnityEngine;

namespace AI.Common.Chase
{
    public class ChaseStateMachine : StateMachine
    {
        public ChaseStateMachine(GameObject agent, GameObject enemy,
            MovementNotifier movementNotifier)
        {
            // Debug.Log("inits chase state machine");
            InitStates(agent, enemy);
            InitTransitions(agent, enemy, movementNotifier);
        }

        public State ChaseState { get; private set; }
        public State CatchState { get; private set; }

        private void InitStates(GameObject agent,
            GameObject enemy)
        {
            InitChaseState(agent, enemy);
            InitCatchState();
        }

        private void InitChaseState(GameObject agent, GameObject enemy)
        {
            ChaseState = new State();
            var chaseAction = new ChaseAction(agent, enemy, 0.01f);
            ChaseState.AddAction(chaseAction);
            AddStateToList(ChaseState);
            EntryState = ChaseState;
        }

        private void InitCatchState()
        {
            CatchState = new State();
            AddStateToList(CatchState);
        }

        private void InitTransitions(GameObject agent, GameObject enemy,
            MovementNotifier movementNotifier)
        {
            var catchToChaseDecision = InitCatchToChaseTransition(agent, enemy, movementNotifier);
            InitChaseToCatchTransition(catchToChaseDecision);
        }

        private CatchToChaseDecision InitCatchToChaseTransition(GameObject agent,
            GameObject enemy,
            MovementNotifier movementNotifier)
        {
            var catchToChaseDecision = new CatchToChaseDecision(agent, enemy, movementNotifier);
            var catchToChaseTransition = new Transition(catchToChaseDecision, ChaseState);
            CatchState.AddTransition(catchToChaseTransition);
            return catchToChaseDecision;
        }

        private void InitChaseToCatchTransition(CatchToChaseDecision catchToChaseDecision)
        {
            var chaseToCatchTransition = new Transition(new OppositeDecision(catchToChaseDecision),
                CatchState);
            ChaseState.AddTransition(chaseToCatchTransition);
        }
    }
}