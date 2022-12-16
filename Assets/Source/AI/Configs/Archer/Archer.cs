using UnityEngine;
using AI.Common.Watch;
using AI.Common.Components;
using AI.Common.Events;

namespace AI.Configs.Archer
{
    public class Archer : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        private void Start()
        {
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
            fov.Value = 12.0f;

            var catchComp = gameObject.GetComponent<Catch>();
            catchComp.Value = 6.0f;
        }

        private void BuildStateMachines()
        {
            var animationNotifier = new AnimationNotifier();
            var spottingManager = room.GetComponent<Room>().SpottingManager;
            _watchStateMachine = new WatchStateMachine(gameObject, enemy, spottingManager);
            _masterStateMachine = new MasterStateMachine(gameObject, firePoint,
                                                         arrowPrefab,
                                                         enemy, spottingManager,
                                                         animationNotifier);
        }

        [SerializeField] private GameObject enemy;

        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private GameObject firePoint;

        [SerializeField] private GameObject room;

        private WatchStateMachine _watchStateMachine;
        private MasterStateMachine _masterStateMachine;
    }
}