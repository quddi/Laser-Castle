using Code.Other;

namespace Code.Enemies
{
    public interface IEnemiesService : IService
    {
        EnemyConfig GetEnemyConfig(int id);
    }
}