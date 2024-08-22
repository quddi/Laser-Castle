using System;
using Code.Other;

namespace Code.Input
{
    public interface IInputService : IService
    {
        public event Action<InputTarget> TargetPressedEvent;
        
        public event Action<InputTarget> TargetUnpressedEvent;

        public void RegisterTarget(InputTarget inputTarget);

        public void UnregisterTarget(InputTarget inputTarget);
    }
}