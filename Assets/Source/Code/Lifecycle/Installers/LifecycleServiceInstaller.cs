using Zenject;

namespace Code.Lifecycle
{
    public class LifecycleServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILifecycleService>()
                .To<LifecycleService>()
                .FromNew()
                .AsSingle();
        }
    }
}