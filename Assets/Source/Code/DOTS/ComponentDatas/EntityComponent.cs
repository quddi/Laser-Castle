using Unity.Entities;

namespace Source.DOTS
{
    public struct EntityComponent : IComponentData
    {
        public Entity Value;
    }
}