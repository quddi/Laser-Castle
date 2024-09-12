using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Rendering.Universal;

namespace Code.DOTS
{
    public readonly partial struct MovementAspect : IAspect
    {
        public readonly RefRW<LocalTransform> LocalTransform;
        public readonly RefRO<MovementSpeedComponent> Movement;

        public float3 Position => LocalTransform.ValueRO.Position;
        
        public void Move(float deltaTime)
        {
            LocalTransform.ValueRW = LocalTransform.ValueRW.Translate(Movement.ValueRO.Vector * deltaTime);
        }
    }
}