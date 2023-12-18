using Zenject;

namespace Code.EntitiesPassing
{
    public class EntitiesPassingServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EntitiesPassingService>()
                .AsSingle();
        }
    }
}