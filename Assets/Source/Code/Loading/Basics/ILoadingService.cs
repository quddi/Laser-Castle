using Cysharp.Threading.Tasks;

namespace Code.Loading
{
    public interface ILoadingService
    {
        public UniTask<bool> TryLoad(string sceneName);
        
        public UniTask LoadBaseScenes();

        public UniTask LoadGameScene();
    }
}