using UnityEngine;

namespace MainSpace.Objects
{
    public sealed class RuntimeData
    {
        public Transform LastTileTransform;
        public readonly int MaxTileCount;

        public RuntimeData(int tileCount)
        {
            MaxTileCount = tileCount;
        }
    }
}
