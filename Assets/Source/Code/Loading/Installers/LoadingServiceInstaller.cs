using System;
using UnityEngine;
using Zenject;

namespace Code.Loading
{
    public class LoadingServiceInstaller : MonoInstaller
    {
        [SerializeField] private LoadingConfig _loadingConfig;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<LoadingService>()
                .AsSingle()
                .WithArguments(_loadingConfig);
        }
    }
}