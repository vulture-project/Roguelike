using UnityEngine;
using AI.Common.Watch;
using AI.Interaction;
using AI.Common.Components;
using AI.Configs.Swordsman.Fight.Stuff;
using AI.Common.Events;

namespace AI.Configs.Swordsman
{
    [RequireComponent(typeof(FieldOfView), typeof(Catch))]
    public class Swordsman : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _animationNotifier = new AnimationNotifier();
            _spottingManager = room.GetComponent<Room>().SpottingManager;
            BuildStateMachines();
            _watchStateMachine.OnEntry();
            _masterStateMachine.OnEntry();
        }

        private void Update()
        {
            _watchStateMachine.Execute();
            _masterStateMachine.Execute();
        }

        private void Init() {
            var fov = gameObject.GetComponent<FieldOfView>();
            fov.Value = 20.0f;

            var catchComp = gameObject.GetComponent<Catch>();
            catchComp.Value = 2.5f;

            var sword = gameObject.GetComponent<Sword>();
        }

        private void BuildStateMachines()
        {
            _watchStateMachine = new WatchStateMachine(gameObject, enemy, _spottingManager);
            _masterStateMachine = new MasterStateMachine(gameObject, enemy,
                                                         _spottingManager,
                                                         _animationNotifier);
        }

        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject room;

        private WatchStateMachine _watchStateMachine;
        private MasterStateMachine _masterStateMachine;

        private SpottingManager _spottingManager;
        private AnimationNotifier _animationNotifier;
    }
}
