using UnityEngine;
using AI.Base;
using AI.Configs.Archer.Fight;
using AI.Common.Roam;
using AI.Interaction;
using Utils.Math;
using AI.Common.Events;

namespace AI.Configs.Archer
{
    public class MasterStateMachine : StateMachine
    {
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

        public RoamStateMachine RoamStateMachine { get; private set; }
        public FightStateMachine FightStateMachine { get; private set; }

        private void InitRoamToFightTransition(SpottingManager spottingManager)
        {
            var roamToFightDecision = new RoamToFightDecision(spottingManager);
            var roamToFightTransition = new Transition(roamToFightDecision, FightStateMachine.EntryState);
            RoamStateMachine.AddTransitionToAllStates(roamToFightTransition);
        }

        private MovementNotifier _movementNotifier;
    }
}