using Unity.Entities;

namespace Code.DOTS
{
    public struct SpawnPositionBoundsComponent : IComponentData
    {
        public float MinX { get; set; }
        public float MaxX { get; set; }
        public float MinY { get; set; }
        public float MaxY { get; set; }
    }
}