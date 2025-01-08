using UnityEngine;

namespace MainSpace.Game.Views
{
    public sealed class CarView : MonoBehaviour
    {
        [SerializeField] private Transform _carTransform;
        [SerializeField] private Transform _turret;

        public Transform CarTransform => _carTransform;
        public Transform TurretTransform => _turret;
    }
}
