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
            
            foreach (var (tileIndexXComponent, entity) in SystemAPI.Query<TileIndexXComponent>()
                         .WithAll<SpawnedTag>()
                         .WithEntityAccess())
            {
                if (!EntityManager.HasComponent<Child>(entity))
                    continue;

                var renderer = entity.GetEnemySpriteRenderer(EntityManager);
                
                renderer.material.SetFloat(IndexX, tileIndexXComponent.Value * 1f);

                entityCommandBuffer.AddComponent<InitializedTag>(entity);
            }
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();
        }
    }
}