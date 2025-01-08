using DI;
using MainSpace.Root;
using UnityEngine;

namespace MainSpace.Game.Root
{
    public sealed class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _carPrefab;
        [SerializeField] private GameObject _gameplayViewPrefab;
        [SerializeField] private EcsStartUp _ecsStartUpPrefab;

        public void Run(DIContainer sceneContainer)
        {
            var rootView = sceneContainer.Resolve<RootView>();

            //rootView.AttachSceneUI(_gameplayViewPrefab);

            // EcsSetupWorld
            var ecsStartUp = Instantiate(_ecsStartUpPrefab);
            ecsStartUp.SetupEcsWorld(sceneContainer);
        }
    }
}
