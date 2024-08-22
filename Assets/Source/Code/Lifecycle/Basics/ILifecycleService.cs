using System;
using Code.Other;
using Cysharp.Threading.Tasks;

namespace Code.Lifecycle
{
    public interface ILifecycleService : IService
    {
        public event Action GamePreparationEvent;
        
        public event Action GameStartEvent;

        public UniTaskVoid Start();
    }
}