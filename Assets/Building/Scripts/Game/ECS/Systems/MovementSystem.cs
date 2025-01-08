using Leopotam.Ecs;
using MainSpace.Game.Ecs.Componments;
using UnityEngine;

namespace MainSpace.Game.Ecs.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<TransformEcs, DirectionComponent, MoveComponent> _moveFilter;
        private EcsFilter<CarMarker, TransformEcs> _carFilrer;

        public void Run()
        {
            ref var carTransform = ref _carFilrer.Get2(0);

            foreach (var i in _moveFilter)
            {
                ref var transform = ref _moveFilter.Get1(i);
                ref var direction = ref _moveFilter.Get2(i);
                ref var moveCompomnent = ref _moveFilter.Get3(i);

                direction.Direction = (carTransform.Transform.position - transform.Transform.position).normalized;
                transform.Transform.Translate(direction.Direction * moveCompomnent.Speed * Time.deltaTime, Space.Self);
            }
        }
    }
}
