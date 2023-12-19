using System;
using UnityEngine;
using Zenject;

namespace Code.Input
{
    public class InputTarget : MonoBehaviour
    {
        [field: SerializeField] public RaycastTargetType Type { get; private set; }
        
        private IInputService _inputService;
        private bool? _previousPressedState;
        
        private bool _pointerOnScreen = false;
        private bool _pointerOnTarget = false;
        private bool _registered = false;
        private bool _constructed = false;

        public bool IsPressed => _pointerOnScreen && _pointerOnTarget;

        public event Action<InputTarget> PressedEvent;
        public event Action<InputTarget> UnpressedEvent;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            
            _constructed = true;
            
            Register();
        }
        

        private void Update()
        {
            if (!_constructed)
                return;
            
            if (_previousPressedState != null)
            {
                if (!_previousPressedState.Value && IsPressed)
                    PressedEvent?.Invoke(this);
                else if (_previousPressedState.Value && !IsPressed)
                    UnpressedEvent?.Invoke(this);
            }

            _previousPressedState = IsPressed;
        }

        private void Register()
        {
            if (!_constructed || _registered)
                return;

            _registered = true;
            
            _inputService.RegisterTarget(this);
        }

        private void Unregister()
        {
            if (!_constructed || !_registered)
                return;

            _registered = false;
            
            _inputService.UnregisterTarget(this);
        }

        private void OnMouseDown() => _pointerOnScreen = true;
        private void OnMouseUp() => _pointerOnScreen = false;
        private void OnMouseEnter() => _pointerOnTarget = true;
        private void OnMouseExit() => _pointerOnTarget = false;

        private void OnEnable()
        {
            Register();
        }

        private void OnDisable()
        {
            Unregister();
        }
    }
}