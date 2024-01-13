using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class GameplayControllersInstaller : MonoInstaller
    {
        [SerializeField, TabGroup("Components")] private GameplayController _gameplayController;
        [SerializeField, TabGroup("Components")] private PlayerController _playerController;

        public override void InstallBindings()
        {
            Container
                .Bind<GameplayController>()
                .FromInstance(_gameplayController);
            
            Container
                .Bind<PlayerController>()
                .FromInstance(_playerController);
        }
    }
}