using Code.Extensions;
using Source.Enemies;
using Unity.Entities;
using UnityEngine;

namespace Source.DOTS
{
    public class EnemiesConfigsAuthoring : MonoBehaviour
    {
        [field: SerializeField] public EnemiesConfig EnemiesConfig { get; private set; }

        public class Baker : Baker<EnemiesConfigsAuthoring>
        {
            public override void Bake(EnemiesConfigsAuthoring authoring)
            {
                var mainEntity = GetEntity(TransformUsageFlags.None);
                var enemiesConfigsContainerComponent = new EnemiesConfigsContainerComponent { Value = mainEntity };
                AddComponent(mainEntity, enemiesConfigsContainerComponent);
                
                var someBuffer = AddBuffer<LinkedEntityGroup>(mainEntity);
                
                foreach (var enemyConfig in authoring.EnemiesConfig.EnemiesConfigs)
                {
                    var configEntity = CreateAdditionalEntity(TransformUsageFlags.None);
                    var prefabEntity = GetEntity(enemyConfig.Prefab, TransformUsageFlags.Dynamic);
                    
                    AddComponent(configEntity, new IdComponent { Value = enemyConfig.Id });
                    AddComponent(configEntity, new EntityComponent { Value = prefabEntity });

                    //var enemyConfigComponent = new EnemyConfigComponent { Value = configEntity };
                    someBuffer.Add(new LinkedEntityGroup {Value = configEntity });
                }
            }
        }
    }
}