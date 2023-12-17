using Code.Lifecycle;
using UnityEngine;
using Zenject;

public class BootstrapController : MonoBehaviour, IInitializable
{
    private ILifecycleService _lifecycleService;

    [Inject]
    private void Construct(ILifecycleService lifecycleService)
    {
        _lifecycleService = lifecycleService;
    }

    [Inject]
    public void Initialize()
    {
        _lifecycleService.Start();
    }
}
