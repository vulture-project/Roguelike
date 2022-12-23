using AI.Common.Aim;
using AI.Common.Components;
using AI.Common.Watch;
using AI.Configs.Archer.Fight.Animations;
using AI.Interaction;
using UnityEngine;

namespace AI.Configs.Archer
{
    [RequireComponent(typeof(AnimationNotifier), typeof(FieldOfView), typeof(Catch))]
    public class Archer : MonoBehaviour
    {
        private AnimationNotifier _animationNotifier;
        private SpottingManager _spottingManager;

        private MasterStateMachine _masterStateMachine;
        private WatchStateMachine _watchStateMachine;
        private AimStateMachine _aimStateMachine;

        private void Update()
        {
            _watchStateMachine?.Execute();
            _masterStateMachine?.Execute();
            _aimStateMachine?.Execute();
        }

        public void Init(GameObject room, GameObject enemy,
                         MasterStateMachineConfig config)
        {
            _animationNotifier = GetComponent<AnimationNotifier>();
            _spottingManager = room.GetComponent<Room>().SpottingManager;

            BuildStateMachines(enemy, config);
            _watchStateMachine.OnEntry();
            _masterStateMachine.OnEntry();
            _aimStateMachine.OnEntry();
        }

        private void BuildStateMachines(GameObject enemy,
                                        MasterStateMachineConfig config)
        {
            _watchStateMachine = new WatchStateMachine(gameObject, enemy, _spottingManager);
            _masterStateMachine = new MasterStateMachine(gameObject, config,
                                                         enemy, _spottingManager,
                                                         _animationNotifier);
            _aimStateMachine = new AimStateMachine(config.AimStateMachineConfig);
        }
    }
}