using Code.Enemies;
using Unity.Entities;
using UnityEngine;

namespace Code.DOTS
{
    public class EnemiesSpawnSystemSetupAuthoring : MonoBehaviour
    {
        [field:SerializeField] public Transform FirstSpawnBoundsPoint { get; private set; }
        [field:SerializeField] public Transform SecondSpawnBoundsPoint { get; private set; }
        
        [field: SerializeField] public EnemiesConfig EnemiesConfig { get; private set; }

        public class Baker : Baker<EnemiesSpawnSystemSetupAuthoring>
        {
            public override void Bake(EnemiesSpawnSystemSetupAuthoring authoring)
            {
                var mainEntity = GetEntity(TransformUsageFlags.None);

                AddComponent(mainEntity, new EnemiesSpawnSystemSetup { Value = mainEntity });
                
                AddSpawnPositionBoundsComponent(authoring, mainEntity);
                
                AddConfigsBuffer(authoring, mainEntity);
            }

            private void AddSpawnPositionBoundsComponent(EnemiesSpawnSystemSetupAuthoring authoring, Entity mainEntity)
            {
                var firstPosition = authoring.FirstSpawnBoundsPoint.position;
                var secondPosition = authoring.SecondSpawnBoundsPoint.position;

                var spawnPositionBoundsComponent = new SpawnPositionBoundsComponent
                {
                    MinX = Mathf.Min(firstPosition.x, secondPosition.x),
                    MaxX = Mathf.Max(firstPosition.x, secondPosition.x),
                    MinY = Mathf.Min(firstPosition.y, secondPosition.y),
                    MaxY = Mathf.Max(firstPosition.y, secondPosition.y),
                };
                
                AddComponent(mainEntity, spawnPositionBoundsComponent);
            }

            private void AddConfigsBuffer(EnemiesSpawnSystemSetupAuthoring authoring, Entity mainEntity)
            {
                var someBuffer = AddBuffer<LinkedEntityGroup>(mainEntity);

                foreach (var enemyConfig in authoring.EnemiesConfig.EnemiesConfigs)
                {
                    var configEntity = CreateAdditionalEntity(TransformUsageFlags.None);
                    var prefabEntity = GetEntity(enemyConfig.Prefab, TransformUsageFlags.Dynamic);
                    
                    AddComponent(configEntity, new IdComponent { Value = enemyConfig.Id });
                    AddComponent(configEntity, new EntityComponent { Value = prefabEntity });
                    AddComponent(configEntity, new MovementSpeedComponent { Vector = enemyConfig.MovementSpeed });

                    someBuffer.Add(new LinkedEntityGroup {Value = configEntity });
                }
            }
        }
    }
}