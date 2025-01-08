using UnityEngine;

namespace MainSpace.Game.Views
{
    public sealed class GroundView : MonoBehaviour
    {
        [SerializeField] private Transform _groundTransform;
        [SerializeField] private Transform _spawnPointLeft;
        [SerializeField] private Transform _spawnPointRight;

        public Transform GroundTransform => _groundTransform;
        public Transform SpawnPointLeft => _spawnPointLeft;
        public Transform SpawnPointRight => _spawnPointRight;
    }
}
