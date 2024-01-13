using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Input
{
    public class InputService : IInputService
    {
        public event Action<InputTarget> TargetPressedEvent;
        public event Action<InputTarget> TargetUnpressedEvent;

        private HashSet<InputTarget> _registeredInputTargets = new();

        public void RegisterTarget(InputTarget inputTarget)
        {
            if (_registeredInputTargets.Contains(inputTarget))
                return;

            _registeredInputTargets.Add(inputTarget);
            
            inputTarget.PressedEvent += InputTargetPressedEvent;
            inputTarget.UnpressedEvent += InputTargetUnpressedEvent;
        }

        public void UnregisterTarget(InputTarget inputTarget)
        {
            if (!_registeredInputTargets.Contains(inputTarget))
                return;

            _registeredInputTargets.Remove(inputTarget);
            
            inputTarget.PressedEvent -= InputTargetPressedEvent;
            inputTarget.UnpressedEvent -= InputTargetUnpressedEvent;
        }

        private void InputTargetPressedEvent(InputTarget inputTarget)
        {
            TargetPressedEvent?.Invoke(inputTarget);
        }

        private void InputTargetUnpressedEvent(InputTarget inputTarget)
        {
            TargetUnpressedEvent?.Invoke(inputTarget);
        }
    }
}