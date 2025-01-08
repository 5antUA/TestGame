using Leopotam.Ecs;
using MainSpace.Game.Ecs.Componments;
using MainSpace.Objects;
using UnityEngine;

namespace MainSpace.Game.Ecs.Systems
{
    public sealed class BackwardObjectDestroyer : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private EcsFilter<BackwardObjectMovement, TransformEcs> _ecsFilter;

        public void Run()
        {
            foreach (var i in _ecsFilter)
            {
                ref var transformEcs = ref _ecsFilter.Get2(i);

                if (transformEcs.Transform.position.z <= -100)
                {
                    Transform transform = transformEcs.Transform;

                    _ecsFilter.GetEntity(i).Destroy();
                    Object.Destroy(transform.gameObject);
                }
            }
        }
    }
}
