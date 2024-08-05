using Source.Enemies;
using UnityEngine;
using Zenject;

namespace Code.Enemies
{
    public class EnemyServiceInstaller : MonoInstaller
    {
        [SerializeField] private EnemiesConfig _enemiesConfig;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemiesService>()
                .AsSingle()
                .WithArguments(_enemiesConfig);
        }
    }
}