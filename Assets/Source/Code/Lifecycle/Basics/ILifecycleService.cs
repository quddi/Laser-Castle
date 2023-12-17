using System;
using Cysharp.Threading.Tasks;

namespace Code.Lifecycle
{
    public interface ILifecycleService
    {
        public event Action GamePreparationEvent;
        
        public event Action GameStartEvent;

        public UniTaskVoid Start();
    }
}