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

        private void Update()
        {
            _watchStateMachine?.Execute();
            _masterStateMachine?.Execute();
        }

        public void Init(GameObject room, GameObject enemy,
                         Transform firePoint, float projectileWidth,
                         float reloadTime)
        {
            _animationNotifier = GetComponent<AnimationNotifier>();
            _spottingManager = room.GetComponent<Room>().SpottingManager;

            BuildStateMachines(room, enemy, firePoint, projectileWidth, reloadTime);
            _watchStateMachine.OnEntry();
            _masterStateMachine.OnEntry();

            var fov = gameObject.GetComponent<FieldOfView>();
            fov.Value = 12.0f;

            var catchComp = gameObject.GetComponent<Catch>();
            catchComp.Value = 6.0f;
        }

        private void BuildStateMachines(GameObject room, GameObject enemy,
                                        Transform firePoint, float projectileWidth,
                                        float reloadTime)
        {
            var animationNotifier = GetComponent<AnimationNotifier>();
            var spottingManager = room.GetComponent<Room>().SpottingManager;
            _watchStateMachine = new WatchStateMachine(gameObject, enemy, spottingManager);
            _masterStateMachine = new MasterStateMachine(gameObject, firePoint,
                                                         projectileWidth,
                                                         reloadTime,
                                                         enemy, spottingManager,
                                                         animationNotifier);
        }
    }
}