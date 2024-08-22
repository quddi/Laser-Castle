using Unity.Entities;

namespace Code.DOTS
{
    public struct EntityComponent : IComponentData
    {
        public Entity Value;
    }
}