using Code.Input;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField, TabGroup("Parameters")] private RaycastTargetType _fieldTargetType;
        
        private IInputService _inputService;
        private PlayerController _playerController;
        private FingerCameraController _fingerCameraController;

        [Inject]
        private void Construct(IInputService inputService, PlayerController playerController, 
            FingerCameraController fingerCameraController)
        {
            _fingerCameraController = fingerCameraController;
            _playerController = playerController;
            _inputService = inputService;
        }

        private void OnTargetPressedHandler(InputTarget inputTarget)
        {
            if (inputTarget.Type != _fieldTargetType) 
                return;
            
            _playerController.SetFocused(true);
            _fingerCameraController.SetFollowFinger(true);
        }

        private void OnTargetUnpressedHandler(InputTarget inputTarget)
        {
            if (inputTarget.Type != _fieldTargetType) 
                return;
            
            _playerController.SetFocused(false);
            _fingerCameraController.SetFollowFinger(false);
        }

        private void OnEnable()
        {
            _inputService.TargetPressedEvent += OnTargetPressedHandler;
            _inputService.TargetUnpressedEvent += OnTargetUnpressedHandler;
        }

        private void OnDisable()
        {
            _inputService.TargetPressedEvent -= OnTargetPressedHandler;
            _inputService.TargetUnpressedEvent -= OnTargetUnpressedHandler;
        }
    }
}