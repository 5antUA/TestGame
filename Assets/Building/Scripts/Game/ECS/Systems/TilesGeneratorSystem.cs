using Leopotam.Ecs;
using MainSpace.Game.Ecs.Componments;
using MainSpace.Objects;
using System.Linq;
using UnityEngine;

namespace MainSpace.Game.Ecs.Systems
{
    public sealed class TilesGeneratorSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private RuntimeData _runtimeData;
        private EcsFilter<TileComponent> _filter;

        public void Init()
        {
            for (int i = 0; i < _runtimeData.MaxTileCount; i++)
            {
                CreateNewTile(_filter.GetEntitiesCount() == 0);
            }
        }

        public void Run()
        {
            int tilesCount = _filter.GetEntitiesCount();

            if (tilesCount < _runtimeData.MaxTileCount)
            {
                CreateNewTile(false);
            }
        }

        private void CreateNewTile(bool isFirstTile)
        {
            var tileEntity = _ecsWorld.NewEntity();

            tileEntity
                .Replace(new TileComponent())
                .Replace(new TransformEcs())
                .Replace(new BackwardObjectMovement())
                .Replace(new OnCreatedTile());

            ref var tileMarker = ref tileEntity.Get<TileComponent>();
            ref var tileTransform = ref tileEntity.Get<TransformEcs>();
            ref var tileMoveComponent = ref tileEntity.Get<BackwardObjectMovement>();

            var tileView = Object.Instantiate(_staticData.GroundPrefab);

            tileMarker.SpawnPointLeft = tileView.SpawnPointLeft;
            tileMarker.SpawnPointRight = tileView.SpawnPointRight;
            tileTransform.Transform = tileView.GroundTransform;
            tileMoveComponent.Speed = _staticData.SimulationSpeed;

            if (isFirstTile)
            {
                _runtimeData.LastTileTransform = tileTransform.Transform;
                return;
            }

            float positionZ = _runtimeData.LastTileTransform.position.z + tileTransform.Transform.localScale.z;
            tileTransform.Transform.position = new Vector3(0, 0, positionZ);

            _runtimeData.LastTileTransform = tileTransform.Transform;
        }
    }
}
