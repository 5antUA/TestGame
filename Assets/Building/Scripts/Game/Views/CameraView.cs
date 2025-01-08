using Cinemachine;
using UnityEngine;

namespace MainSpace.Game.Views
{
    public sealed class CameraView : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        [SerializeField] private float _offsetY = 15.5f;
        [SerializeField] private float _offsetZ = -30f;

        public CinemachineVirtualCamera VirtualCamera => _virtualCamera;

        public float OffsetY => _offsetY;
        public float OffsetZ => _offsetZ;
    }
}
