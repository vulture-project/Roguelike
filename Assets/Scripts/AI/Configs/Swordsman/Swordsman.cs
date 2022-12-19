using AI.Common.Components;
using AI.Common.Events;
using AI.Common.Watch;
using AI.Configs.Swordsman.Fight.Stuff;
using AI.Interaction;
using UnityEngine;

namespace AI.Configs.Swordsman
{
    [RequireComponent(typeof(FieldOfView), typeof(Catch))]
    public class Swordsman : MonoBehaviour
    {
        private AnimationNotifier _animationNotifier;
        private MasterStateMachine _masterStateMachine;

        private SpottingManager _spottingManager;

        private WatchStateMachine _watchStateMachine;

        private void Update()
        {
            _watchStateMachine?.Execute();
            _masterStateMachine?.Execute();
        }

        public void Init(GameObject room, GameObject enemy)
        {
            _animationNotifier = new AnimationNotifier();
            _spottingManager = room.GetComponent<Room>().SpottingManager;
            BuildStateMachines(room, enemy);
            _watchStateMachine.OnEntry();
            _masterStateMachine.OnEntry();
            
            var fov = gameObject.GetComponent<FieldOfView>();
            fov.Value = 20.0f;

            var catchComp = gameObject.GetComponent<Catch>();
            catchComp.Value = 3.0f;

            var sword = gameObject.GetComponent<Sword>();
        }

        private void BuildStateMachines(GameObject room, GameObject enemy)
        {
            _watchStateMachine = new WatchStateMachine(gameObject, enemy, _spottingManager);
            _masterStateMachine = new MasterStateMachine(gameObject, enemy,
                _spottingManager,
                _animationNotifier);
        }
    }
}