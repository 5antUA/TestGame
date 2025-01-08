using Leopotam.Ecs;
using MainSpace.Game.Ecs.Componments;
using MainSpace.Objects;
using UnityEngine;

namespace MainSpace.Game.Ecs.Systems
{
    public sealed class StickmanGeneratorSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private EcsFilter<OnCreatedTile> _eventFilter;
        private EcsFilter<CarMarker, TransformEcs> _carFilrer;

        public void Run()
        {
            ref var carTransform = ref _carFilrer.Get2(0);

            foreach (var i in _eventFilter)
            {
                ref var entity = ref _eventFilter.GetEntity(i);

                SpawnNewStickman(entity, carTransform);

                entity.Del<OnCreatedTile>();
            }
        }

        private void SpawnNewStickman(EcsEntity tileEntity, TransformEcs carTransform)
        {
            ref var tileComponent = ref tileEntity.Get<TileComponent>();
            ref var tileTransform = ref tileEntity.Get<TransformEcs>();
            ref var move = ref tileEntity.Get<MoveComponent>();

            tileComponent.StickmansList = new();

            for (int i = 0; i < 5; i++)
            {
                var stickmanEntity = _ecsWorld.NewEntity();

                stickmanEntity
                    .Replace(new StickmanMarker())
                    .Replace(new TransformEcs())
                    .Replace(new DirectionComponent())
                    .Replace(new MoveComponent())
                    .Replace(new BackwardObjectMovement());

                ref var stickmanTransform = ref stickmanEntity.Get<TransformEcs>();
                ref var stickmanDirection = ref stickmanEntity.Get<DirectionComponent>();
                ref var stickmanMoveComponent = ref stickmanEntity.Get<MoveComponent>();
                ref var stickmanSimulationMovement = ref stickmanEntity.Get<BackwardObjectMovement>();

                float randPosX = Random.Range(tileComponent.SpawnPointLeft.position.x, tileComponent.SpawnPointRight.position.x);
                float randPosZ = Random.Range(
                    tileTransform.Transform.position.z + tileTransform.Transform.localScale.z / 2,
                    tileTransform.Transform.position.z - tileTransform.Transform.localScale.z / 2);
                Vector3 stickmanPosition = new Vector3(randPosX, 0, randPosZ);

                var stickmanGO = Object.Instantiate(_staticData.StickmanPrefab, stickmanPosition, Quaternion.identity);

                stickmanTransform.Transform = stickmanGO.transform;
                //stickmanDirection.Direction = (carTransform.Transform.position - stickmanTransform.Transform.position).normalized;
                stickmanDirection.Direction.z = 0;
                stickmanMoveComponent.Speed = 10f;
                stickmanSimulationMovement.Speed = _staticData.SimulationSpeed;

                tileComponent.StickmansList.Add(stickmanEntity);
            }
        }
    }
}
