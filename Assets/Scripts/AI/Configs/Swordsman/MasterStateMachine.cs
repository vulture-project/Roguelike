using AI.Base;
using AI.Common.Death;
using AI.Common.Events;
using AI.Common.Roam;
using AI.Configs.Swordsman.Fight;
using AI.Interaction;
using UnityEngine;
using AI.Configs.Swordsman.Fight.Animations;

namespace AI.Configs.Swordsman
{
    public class MasterStateMachine : StateMachine
    {

        private readonly FightStateMachine FightStateMachine;
        private readonly RoamStateMachine RoamStateMachine;
        public MasterStateMachine(GameObject agent, GameObject enemy,
                                  MasterStateMachineConfig config,
                                  SpottingManager spottingManager,
                                  AnimationNotifier animationNotifier)
        {
            var movementNotifier = new MovementNotifier();

            RoamStateMachine = new RoamStateMachine(agent, config.RoamStateMachineConfig);
            FightStateMachine = new FightStateMachine(agent, config.FightStateMachineConfig,
                                                      movementNotifier,
                                                      animationNotifier, enemy);

            MergeCore(this, RoamStateMachine);
            MergeCore(this, FightStateMachine);

            BuildRoamToFightTransition(spottingManager);
            BuildDeath(agent, animationNotifier);
            
            EntryState = RoamStateMachine.EntryState;
        }

        private void BuildRoamToFightTransition(SpottingManager spottingManager)
        {
            var roamToFightDecision = new RoamToFightDecision(spottingManager);
            var roamToFightTransition = new Transition(roamToFightDecision,
                FightStateMachine.EntryState);
            RoamStateMachine.AddTransitionToAllStates(roamToFightTransition);
        }

        private void BuildDeath(GameObject agent, AnimationNotifier animationNotifier)
        {
            var died = new State();
            died.AddAction(new DieAction(agent));
            var toDiedDecision = new ToDiedDecision(animationNotifier);
            var toDiedTransition = new Transition(toDiedDecision, died);
            AddTransitionToAllStates(toDiedTransition);
            AddStateToList(died);
        }
    }
}