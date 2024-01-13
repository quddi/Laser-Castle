using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class GameplayControllersInstaller : MonoInstaller
    {
        [SerializeField, TabGroup("Components")] private GameplayController _gameplayController;
        [SerializeField, TabGroup("Components")] private PlayerController _playerController;
        [SerializeField, TabGroup("Components")] private FingerCameraController _fingerCameraController;

        public override void InstallBindings()
        {
            Container
                .Bind<GameplayController>()
                .FromInstance(_gameplayController);
            
            Container
                .Bind<PlayerController>()
                .FromInstance(_playerController);

            Container
                .Bind<FingerCameraController>()
                .FromInstance(_fingerCameraController);
        }
    }
}