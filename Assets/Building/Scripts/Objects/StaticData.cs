using MainSpace.Game.Views;
using UnityEngine;

namespace MainSpace.Objects
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "Data/Create StaticData")]
    public sealed class StaticData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private CarView _carPrefab;
        [SerializeField] private CameraView _cameraPrefab;
        [SerializeField] private GroundView _groundPrefab;
        [SerializeField] private GameObject _stickmanPrefab;

        [Header("Other data")]
        [SerializeField, Range(2, 10)] private int _maxTileCount;
        [SerializeField] private int _simulationSpeed;

        public CarView CarPrefab => _carPrefab;
        public CameraView CameraPrefab => _cameraPrefab;
        public GroundView GroundPrefab => _groundPrefab;
        public GameObject StickmanPrefab => _stickmanPrefab;

        public int MaxTileCount => _maxTileCount;
        public int SimulationSpeed => _simulationSpeed;
    }
}