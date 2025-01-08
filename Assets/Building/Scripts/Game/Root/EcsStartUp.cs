using DI;
using Leopotam.Ecs;
using MainSpace.Game.Ecs.Systems;
using MainSpace.Objects;
using UnityEngine;

namespace MainSpace.Game.Root
{
    public sealed class EcsStartUp : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;   // inject

        private EcsWorld _ecsWorld;                        // auto-inject
        private EcsSystems _ecsSystems;                    // auto-inject
        private RuntimeData _runtimeData;                  // inject

        public void SetupEcsWorld(DIContainer sceneContainer)
        {
            _ecsWorld = new EcsWorld();
            _ecsSystems = new EcsSystems(_ecsWorld);
            _runtimeData = new RuntimeData(_staticData.MaxTileCount);

            AddSystems();
            DependencyInjection();

            _ecsSystems.Init();
        }

        private void AddSystems()
        {
            _ecsSystems
                .Add(new SpawnCarSystem())
                .Add(new TilesGeneratorSystem())
                .Add(new StickmanGeneratorSystem())
                .Add(new MovementSystem())
                .Add(new BackwardMovementSystem())
                .Add(new BackwardObjectDestroyer());
        }

        private void DependencyInjection()
        {
            _ecsSystems
                .Inject(_staticData)
                .Inject(_runtimeData);
        }

        public void Update()
        {
            _ecsSystems.Run();
        }

        private void OnDestroy()
        {
            if (_ecsSystems != null)
            {
                _ecsSystems.Destroy();
                _ecsSystems = null;
                _ecsWorld.Destroy();
                _ecsWorld = null;
            }
        }
    }
}
