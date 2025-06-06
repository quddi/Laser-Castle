using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Code.DOTS
{
    public partial class AtlasAnimationSystem : SystemBase
    {
        private static readonly int IndexY = Shader.PropertyToID("_IndexY");

        protected override void OnUpdate()
        {
            foreach (var (aspect, entity) in SystemAPI.Query<AtlasAnimationAspect>().WithEntityAccess())
            {
                bool frameChanged = aspect.AddTime(SystemAPI.Time.DeltaTime);
                
                if (!frameChanged)
                    continue;

                var currentFrameIndex = aspect.AtlasAnimationState.ValueRO.CurrentFrameIndex;
                
                var children = EntityManager.GetBuffer<Child>(entity);
                
                EntityManager.GetComponentObject<SpriteRenderer>(children[0].Value)
                    .material.SetFloat(IndexY, currentFrameIndex);
            }
        }
    }
}