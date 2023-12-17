using System;
using System.Linq;
using Code.Lifecycle;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Loading
{
    public class LoadingService : ILoadingService
    {
        private ILifecycleService _lifecycleService;
        private LoadingConfig _loadingConfig;

        private string _currentSceneName;

        [Inject]
        private void Construct(LoadingConfig loadingConfig)
        {
            _loadingConfig = loadingConfig;
        }

        public async UniTask<bool> TryLoad(string sceneName)
        {
            if (!CanSceneBeLoaded(sceneName))
                return false;

            if (!string.IsNullOrEmpty(_currentSceneName))
                await SceneManager.UnloadSceneAsync(_currentSceneName);

            var startScenesCount = SceneManager.sceneCount;
            
            var scene = SceneManager.LoadScene(sceneName, new LoadSceneParameters(LoadSceneMode.Additive));
            
            while (SceneManager.loadedSceneCount == startScenesCount)
            {
                await UniTask.Yield();
            }

            SceneManager.SetActiveScene(scene);
            
            return true;
        }

        private bool CanSceneBeLoaded(string sceneName)
        {
            return SceneUtility.GetBuildIndexByScenePath(sceneName) != -1;
        }

        public async UniTask LoadBaseScenes()
        {
            var sceneNames = _loadingConfig.BaseScenesNames.ToList();

            await SceneManager.LoadSceneAsync(sceneNames[0], new LoadSceneParameters(LoadSceneMode.Single));
            
            var loadSceneParameters = new LoadSceneParameters(LoadSceneMode.Additive);

            for (var i = 1; i < sceneNames.Count; i++)
                await SceneManager.LoadSceneAsync(sceneNames[i], loadSceneParameters);
        }

        public async UniTask LoadGameScene()
        {
            await TryLoad(_loadingConfig.GameSceneName);
        }
    }
}