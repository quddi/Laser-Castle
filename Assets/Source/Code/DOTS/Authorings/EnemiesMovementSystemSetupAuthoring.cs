using Unity.Entities;
using UnityEngine;

namespace Code.DOTS
{
    public class EnemiesMovementSystemSetupAuthoring : MonoBehaviour
    {
        [field: SerializeField] public Transform MinEnemyYPoint { get; private set; }
        
        public class Baker : Baker<EnemiesMovementSystemSetupAuthoring>
        {
            public override void Bake(EnemiesMovementSystemSetupAuthoring authoring)
            {
                var mainEntity = GetEntity(TransformUsageFlags.None);

                AddComponent(mainEntity, new EnemiesMovementSystemSetup
                {
                    MinY = authoring.MinEnemyYPoint.position.y
                });
            }
        }
    }
}