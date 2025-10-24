using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LaserSystem2D
{
    [Serializable]
    public class LaserSpotGroup
    {
        [SerializeField] private Transform _first;
        [SerializeField] private Transform _second;

        public Transform First => _first;
        public Transform Second => _second;

        public Transform GetRandom()
        {
            return Random.Range(0, 2) == 1 ? _first : _second;
        }

        public Transform this[int index] => index switch
        {
            0 => _first,
            1 => _second,
            _ => null
        };
    }
}