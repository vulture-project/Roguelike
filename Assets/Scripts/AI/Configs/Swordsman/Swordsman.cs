using AI.Common.Components;
using AI.Common.Watch;
using AI.Interaction;
using UnityEngine;
using AI.Configs.Swordsman.Fight.Animations;

namespace AI.Configs.Swordsman
{
    [RequireComponent(typeof(AnimationNotifier), typeof(FieldOfView), typeof(Catch))]
    public class Swordsman : MonoBehaviour
    {
        private AnimationNotifier _animationNotifier;
        private SpottingManager _spottingManager;

        private MasterStateMachine _masterStateMachine;
        private WatchStateMachine _watchStateMachine;

        private void Update()
        {
            _watchStateMachine?.Execute();
            _masterStateMachine?.Execute();
        }

        public void Init(GameObject room, GameObject enemy, MasterStateMachineConfig config)
        {
            _animationNotifier = GetComponent<AnimationNotifier>();
            _spottingManager = room.GetComponent<Room>().SpottingManager;

            BuildStateMachines(enemy, config);
            _watchStateMachine.OnEntry();
            _masterStateMachine.OnEntry();
        }

        private void BuildStateMachines(GameObject enemy, MasterStateMachineConfig config)
        { 
            _watchStateMachine = new WatchStateMachine(gameObject, enemy, _spottingManager);
            _masterStateMachine = new MasterStateMachine(gameObject, enemy, config,
                                                         _spottingManager,
                                                         _animationNotifier);
        }
    }
}