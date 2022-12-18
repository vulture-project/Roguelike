using AI.Base;
using AI.Common.Events;
using AI.Common.Roam;
using AI.Configs.Archer.Fight;
using AI.Interaction;
using UnityEngine;
using Utils.Math;

namespace AI.Configs.Archer
{
    public class MasterStateMachine : StateMachine
    {
        private readonly MovementNotifier _movementNotifier;

        public MasterStateMachine(GameObject agent, GameObject firePoint,
            GameObject arrowPrefab, GameObject enemy,
            SpottingManager spottingManager,
            AnimationNotifier animationNotifier)
        {
            _movementNotifier = new MovementNotifier();

            RoamStateMachine = new RoamStateMachine(agent,
                new Range(1.0f, 2.0f),
                new Range(1.0f, 2.0f));
            FightStateMachine = new FightStateMachine(agent, firePoint, arrowPrefab,
                enemy, _movementNotifier,
                animationNotifier);
            MergeCore(this, RoamStateMachine);
            MergeCore(this, FightStateMachine);

            InitRoamToFightTransition(spottingManager);

            EntryState = RoamStateMachine.EntryState;
        }

        public RoamStateMachine RoamStateMachine { get; }
        public FightStateMachine FightStateMachine { get; }

        private void InitRoamToFightTransition(SpottingManager spottingManager)
        {
            var roamToFightDecision = new RoamToFightDecision(spottingManager);
            var roamToFightTransition = new Transition(roamToFightDecision, FightStateMachine.EntryState);
            RoamStateMachine.AddTransitionToAllStates(roamToFightTransition);
        }
    }
}