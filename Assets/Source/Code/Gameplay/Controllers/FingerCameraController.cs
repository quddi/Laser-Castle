using Code.EntitiesPassing;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class FingerCameraController : MonoBehaviour
    {
        [SerializeField, TabGroup("Parameters")] private string _cameraKey;
        [SerializeField, TabGroup("Parameters")] private float _followCameraZPosition;
        
        [SerializeField, TabGroup("Components")] private Transform _followCameraTransform;
        
        private IEntitiesPassingService _entitiesPassingService;

        private Camera _mainCamera;
        private bool _followFinger;

        [Inject]
        private void Construct(IEntitiesPassingService entitiesPassingService)
        {
            _entitiesPassingService = entitiesPassingService;
            _entitiesPassingService = entitiesPassingService;
            
            OnCameraChangedHandler(_cameraKey, _entitiesPassingService.Get(_cameraKey));

            _entitiesPassingService.OnEntitySetEvent += OnCameraChangedHandler;
        }

        public void SetFollowFinger(bool value)
        {
            _followFinger = value;
        }
        
        private void LateUpdate()
        {
            if (!_followFinger)
                return;
            
            var cameraPosition = _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

            cameraPosition.z = _followCameraZPosition;
            
            _followCameraTransform.position = cameraPosition;
        }
        
        private void OnCameraChangedHandler(string key, object newCamera)
        {
            if (key != _cameraKey || newCamera is not Camera camera) 
                return;

            _mainCamera = camera;
        }

        private void OnDestroy()
        {
            if (_entitiesPassingService != null)
                _entitiesPassingService.OnEntitySetEvent -= OnCameraChangedHandler;
        }
    }
}