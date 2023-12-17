using System;
using Code.Loading;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Code.Lifecycle
{
    public class LifecycleService : ILifecycleService
    {
        private ILoadingService _loadingService;
        
        public event Action GamePreparationEvent;
        public event Action GameStartEvent;

        [Inject]
        private void Construct(ILoadingService loadingService)
        {
            _loadingService = loadingService;
        }
        
        public async UniTaskVoid Start()
        {
            GamePreparationEvent?.Invoke();

            await _loadingService.LoadBaseScenes();

            GameStartEvent?.Invoke();

            await _loadingService.LoadGameScene();
        }
    }
}