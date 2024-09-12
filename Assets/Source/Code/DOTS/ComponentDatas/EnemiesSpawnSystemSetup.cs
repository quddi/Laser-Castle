using Unity.Entities;
using Unity.Mathematics;

namespace Code.DOTS
{
    public struct EnemiesSpawnSystemSetup : IComponentData
    {
        public Entity Value;
    }
}