using Cinemachine;
using Leopotam.Ecs;
using MainSpace.Game.Ecs.Componments;
using MainSpace.Objects;
using UnityEngine;

namespace MainSpace.Game.Ecs.Systems
{
    public sealed class SpawnCarSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _prefabs;

        public void Init()
        {
            var carEntity = _ecsWorld.NewEntity();
            var cameraEntity = _ecsWorld.NewEntity();
            var turretEntity = _ecsWorld.NewEntity();

            carEntity
                .Replace(new CarMarker())
                .Replace(new TransformEcs());

            cameraEntity.Replace(new CameraComponent());

            turretEntity
                .Replace(new TurretMarker())
                .Replace(new TransformEcs());

            ref var carTransform = ref carEntity.Get<TransformEcs>();
            ref var cameraComponent = ref cameraEntity.Get<CameraComponent>();
            ref var turretTransform = ref turretEntity.Get<TransformEcs>();

            var carView = Object.Instantiate(_prefabs.CarPrefab);
            var cameraView = Object.Instantiate(_prefabs.CameraPrefab);

            carTransform.Transform = carView.CarTransform;
            turretTransform.Transform = carView.TurretTransform;

            cameraComponent.VirtualCamera = cameraView.VirtualCamera;
            cameraComponent.CameraFollow = cameraView.VirtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

            cameraComponent.VirtualCamera.Follow = carTransform.Transform;
            cameraComponent.VirtualCamera.LookAt = carTransform.Transform;
            cameraComponent.CameraFollow.ShoulderOffset.y = cameraView.OffsetY;
            cameraComponent.CameraFollow.ShoulderOffset.z = cameraView.OffsetZ;
        }
    }
}
