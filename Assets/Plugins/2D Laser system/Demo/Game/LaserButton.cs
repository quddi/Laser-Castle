using System.Collections.Generic;
using UnityEngine;

namespace LaserSystem2D
{
    public class LaserButton : MonoBehaviour, ILaserEntered, IRestart
    {
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Laser _laser;

        private void Start()
        {
            _laser.Enable();
        }

        public void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            _spriteRenderer.sprite = _enableSprite;
            _laser.Disable();
        }

        public void Restart()
        {
            _spriteRenderer.sprite = _disableSprite;
            _laser.Enable();
        }
    }
}