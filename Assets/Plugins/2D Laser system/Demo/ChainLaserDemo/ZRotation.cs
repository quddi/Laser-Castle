using UnityEngine;

namespace LaserSystem2D
{
    public class ZRotation : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.rotation *= Quaternion.Euler(0, 0, _speed * Time.deltaTime);
        }
    }
}