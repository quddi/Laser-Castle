using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Source.Enemies
{
    public class EnemiesService : IEnemiesService
    {
        private EnemiesConfig _enemiesConfig;

        private Dictionary<int, EnemyConfig> _enemiesConfigs;

        [Inject]
        private void Construct(EnemiesConfig enemiesConfig)
        {
            _enemiesConfig = enemiesConfig;

            _enemiesConfigs = _enemiesConfig.EnemiesConfigs.ToDictionary(config => config.Id, config => config);
        }
        
        public EnemyConfig GetEnemyConfig(int id)
        {
            return _enemiesConfigs.GetValueOrDefault(id);
        }
    }
}