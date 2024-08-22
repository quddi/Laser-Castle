using System.Collections.Generic;
using System.Linq;
using Code.DOTS;
using Code.Lifecycle;
using Code.Other;
using Unity.Entities;
using UnityEngine;
using Zenject;

public class BootstrapController : MonoBehaviour, IInitializable
{
    private ILifecycleService _lifecycleService;
    private HashSet<IService> _services;

    [Inject]
    private void Construct(ILifecycleService lifecycleService, IEnumerable<IService> services)
    {
        _lifecycleService = lifecycleService;
        _services = services.ToHashSet();
        _services.Add(_lifecycleService);
    }

    [Inject]
    public void Initialize()
    {
        var serviceSystem = World.DefaultGameObjectInjectionWorld
            .GetOrCreateSystemManaged<ServicesSystem>();
        
        SetEcsServices(serviceSystem);
        
        _lifecycleService.Start();
    }

    private void SetEcsServices(ServicesSystem servicesSystem)
    {
        foreach (var service in _services)
        {
            servicesSystem.Set(service);
        }
    }
}
