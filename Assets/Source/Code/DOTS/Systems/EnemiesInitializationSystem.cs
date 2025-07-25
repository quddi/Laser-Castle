using Code.DOTS.Tags;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Code.DOTS
{
    public partial class EnemiesInitializationSystem : SystemBase
    {
        private static readonly int IndexX = Shader.PropertyToID("_IndexX");

        protected override void OnUpdate()
        {
            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (var (idComponent, entity) in SystemAPI.Query<IdComponent>()
                         .WithAll<SpawnedTag>()
                         .WithEntityAccess())
            {
                if (!EntityManager.HasComponent<Child>(entity))
                    continue;

                var renderer = entity.GetEnemySpriteRenderer(EntityManager);
                
                renderer.material.SetFloat(IndexX, idComponent.Value * 1f);

                //entityCommandBuffer.RemoveComponent<SpawnedTag>(entity);   
                entityCommandBuffer.AddComponent<InitializedTag>(entity);
            }
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}