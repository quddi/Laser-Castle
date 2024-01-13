using Code.Input;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class SearchCoverView : MonoBehaviour
    {
        [SerializeField, TabGroup("Parameters")] private RaycastTargetType _fieldTargetType;
        
        [SerializeField, TabGroup("Components")] private Animator _animator;
        
        private IInputService _inputService;
        
        private static readonly int FocusedKey = Animator.StringToHash("Focused");

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            
            _inputService.TargetPressedEvent += OnTargetPressedHandler;
            _inputService.TargetUnpressedEvent += OnTargetUnpressedHandler;
        }

        private void OnTargetPressedHandler(InputTarget inputTarget)
        {
            if (inputTarget.Type != _fieldTargetType)
                return;
            
            _animator.SetBool(FocusedKey, true);
        }

        private void OnTargetUnpressedHandler(InputTarget inputTarget)
        {
            if (inputTarget.Type != _fieldTargetType)
                return;
            
            _animator.SetBool(FocusedKey, false);
        }

        private void OnDestroy()
        {
            _inputService.TargetPressedEvent -= OnTargetPressedHandler;
            _inputService.TargetUnpressedEvent -= OnTargetUnpressedHandler;
        }
    }
}