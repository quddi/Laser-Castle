using Unity.Entities;
using Unity.Mathematics;

namespace Code.DOTS
{
    public struct MovementSpeedComponent : IComponentData
    {
        public float3 Vector;
    }
}