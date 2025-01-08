using Cinemachine;
using System;

namespace MainSpace.Game.Ecs.Componments
{
    [Serializable]
    public struct CameraComponent
    {
        public CinemachineVirtualCamera VirtualCamera;
        public Cinemachine3rdPersonFollow CameraFollow;
    }
}
