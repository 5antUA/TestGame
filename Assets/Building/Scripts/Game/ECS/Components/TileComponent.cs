using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainSpace.Game.Ecs.Componments
{
    [Serializable]
    public struct TileComponent
    {
        public Transform SpawnPointLeft;
        public Transform SpawnPointRight;

        public List<EcsEntity> StickmansList;
    }
}
