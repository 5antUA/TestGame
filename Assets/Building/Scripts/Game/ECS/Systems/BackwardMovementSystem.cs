using Leopotam.Ecs;
using MainSpace.Game.Ecs.Componments;
using UnityEngine;

namespace MainSpace.Game.Ecs.Systems
{
    public sealed class BackwardMovementSystem : IEcsRunSystem
    {
        private EcsFilter<BackwardObjectMovement, TransformEcs> _ecsFilter;

        public void Run()
        {
            foreach (var i in _ecsFilter)
            {
                ref var movement = ref _ecsFilter.Get1(i);
                ref var ecsTransform = ref _ecsFilter.Get2(i);

                ecsTransform.Transform.Translate(Vector3.back * movement.Speed * Time.deltaTime, Space.World);
            }
        }
    }
}
