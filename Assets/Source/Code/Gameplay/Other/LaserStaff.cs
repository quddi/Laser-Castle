using System;
using LaserSystem2D;
using UnityEngine;

public class LaserStaff : MonoBehaviour
{
    [SerializeField] private Laser _laser;
    [SerializeField] private Transform _anchor;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _laser.Enable(_anchor);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _laser.Disable();
        }
    }
}
