using UnityEngine;

namespace LaserSystem2D
{
    public class PointsGeneration : MonoBehaviour
    {
        [SerializeField] private AutomaticLaser _automaticLaser;
        [SerializeField] private ChainLaser _chainLaser;
        [SerializeField] private Transform[] _keyPoints;

        private void OnEnable()
        {
            _automaticLaser.LaserEnable += _keyPoints.Shuffle;
        }

        private void OnDisable()
        {
            _automaticLaser.LaserEnable -= _keyPoints.Shuffle;
        }

        private void Update()
        {
            _chainLaser.KeyPoints.Clear();
                
            foreach (Transform point in _keyPoints)
            {
                _chainLaser.KeyPoints.Add(point.position);
            }
                
            _chainLaser.KeyPoints.Add(_keyPoints[0].position);
        }
    }
}