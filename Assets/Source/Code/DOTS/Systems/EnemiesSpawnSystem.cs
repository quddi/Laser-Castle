using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.DOTS
{
    public partial class EnemiesSpawnSystem : SystemBase
    {

        protected override void OnCreate()
        {
            RequireForUpdate<EnemiesConfigsContainerComponent>();
        }

        protected override void OnUpdate()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.Space))
                return;

            var mainEntity = SystemAPI.GetSingletonEntity<EnemiesConfigsContainerComponent>();
            var configsComponent = EntityManager.GetComponentData<EnemiesConfigsContainerComponent>(mainEntity);
            var buffer = EntityManager.GetBuffer<LinkedEntityGroup>(configsComponent.Value);
            var randomConfig = buffer.Random().Value;
            var entityComponent = EntityManager.GetComponentData<EntityComponent>(randomConfig);
            
            var entity = EntityManager.Instantiate(entityComponent.Value);
            
            SetStartPosition(mainEntity, entity);
        }

        private void SetStartPosition(Entity mainEntity, Entity entity)
        {
            var spawnPositionBoundsComponent = EntityManager.GetComponentData<SpawnPositionBoundsComponent>(mainEntity);
            var x = Random.Range(spawnPositionBoundsComponent.MinX, spawnPositionBoundsComponent.MaxX);
            var y = Random.Range(spawnPositionBoundsComponent.MinY, spawnPositionBoundsComponent.MaxY);
            
            SystemAPI.SetComponent(entity, LocalTransform.FromPosition(new float3(x, y,0)));
        }
    }
}