using Code.DOTS.Tags;
using Code.Extensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.DOTS
{
    public partial class EnemiesSpawnSystem : SystemBase
    {
        private static readonly int IndexX = Shader.PropertyToID("_IndexX");

        protected override void OnCreate()
        {
            RequireForUpdate<EnemiesSpawnSystemSetup>();
        }

        protected override void OnUpdate()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.Space))
                return;

            var mainEntity = SystemAPI.GetSingletonEntity<EnemiesSpawnSystemSetup>();
            var configsComponent = EntityManager.GetComponentData<EnemiesSpawnSystemSetup>(mainEntity);
            var buffer = EntityManager.GetBuffer<LinkedEntityGroup>(configsComponent.Value);
            var randomConfig = buffer.Random().Value;
            
            var entity = CreateEnemy(randomConfig);

            SetStartPosition(mainEntity, entity);

            AddEntityComponentsDatas(entity, randomConfig);
            
            EntityManager.AddComponent<SpawnedTag>(entity);
            
            var idComponent = EntityManager.GetComponentData<IdComponent>(randomConfig);

            EntityManager.AddComponentData(entity, idComponent);
        }

        private Entity CreateEnemy(Entity randomConfig)
        {
            var entityComponent = EntityManager.GetComponentData<EntityComponent>(randomConfig);

            var entity = EntityManager.Instantiate(entityComponent.Value);
            
            return entity;
        }

        private void SetStartPosition(Entity mainEntity, Entity entity)
        {
            var spawnPositionBoundsComponent = EntityManager.GetComponentData<SpawnPositionBoundsComponent>(mainEntity);
            var x = Random.Range(spawnPositionBoundsComponent.MinX, spawnPositionBoundsComponent.MaxX);
            var y = Random.Range(spawnPositionBoundsComponent.MinY, spawnPositionBoundsComponent.MaxY);
            
            SystemAPI.SetComponent(entity, LocalTransform.FromPosition(new float3(x, y,0)));
        }

        private void AddEntityComponentsDatas(Entity entity, Entity randomConfig)
        {
            EntityManager.AddComponent<EnemyComponent>(entity);

            var movementSpeed = EntityManager.GetComponentData<MovementSpeedComponent>(randomConfig);
            var atlasAnimation = EntityManager.GetComponentData<AtlasAnimationComponent>(randomConfig);
            
            EntityManager.AddComponentData(entity, movementSpeed);
            EntityManager.AddComponentData(entity, new AnimationTimeComponent());
            EntityManager.AddComponentData(entity, new AtlasAnimationStateComponent());
            EntityManager.AddComponentData(entity, atlasAnimation);
        }
    }
}