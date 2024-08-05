using Source.DOTS;
using Source.Enemies;
using Unity.Entities;
using UnityEngine;

namespace Source.Code
{
    public class EnemiesConfigsAuthoring : MonoBehaviour
    {
        [field: SerializeField] public EnemiesConfig EnemiesConfig { get; private set; }

        public class Baker : Baker<EnemiesConfigsAuthoring>
        {
            /*public override void Bake(SpawningCubeConfigAuthoring authoring)
            {
                authoring.
                var entity = GetEntity(TransformUsageFlags.None);

                var component = new SpawnCubesConfig
                {
                    CubePrefabEntity = GetEntity(authoring._cubePrefab, TransformUsageFlags.Dynamic),
                    AmountToSpawn = authoring._amountToSpawn,
                };

                AddComponent(entity, component);
            }*/

            public override void Bake(EnemiesConfigsAuthoring authoring)
            {
                foreach (var enemyConfig in authoring.EnemiesConfig.EnemiesConfigs)
                {
                    var entity = CreateAdditionalEntity(TransformUsageFlags.None);
                    var prefabEntity = GetEntity(enemyConfig.Prefab, TransformUsageFlags.Dynamic);
                    
                    AddComponent(entity, new IdComponent { Value = enemyConfig.Id });
                    AddComponent(entity, new EntityComponent { Value = prefabEntity });
                }
            }
        }
    }
}