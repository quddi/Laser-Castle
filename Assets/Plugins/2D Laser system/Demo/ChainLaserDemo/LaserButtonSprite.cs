using System.Collections.Generic;
using UnityEngine;

namespace LaserSystem2D
{
    public class LaserButtonSprite : MonoBehaviour, ILaserEntered, ILaserExited
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _disableSprite;
        [SerializeField] private Sprite _enableSprite;

        public void OnLaserEntered(LaserBase laserBase, List<RaycastHit2D> hits)
        {
            _spriteRenderer.sprite = _enableSprite;
        }

        public void OnLaserExited(LaserBase laserBase)
        {
            if (_spriteRenderer != null)
                _spriteRenderer.sprite = _disableSprite;
        }
    }
}