using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Code.DOTS
{
    public partial struct EnemiesMovementSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemiesMovementSystemSetup>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var setupEntity = SystemAPI.GetSingletonEntity<EnemiesMovementSystemSetup>();
            var setup = state.EntityManager.GetComponentData<EnemiesMovementSystemSetup>(setupEntity);
            
            var entitiesToRemove = new NativeList<Entity>(Allocator.Temp);
            
            foreach (var (aspect, entity) in SystemAPI.Query<MovementAspect>()
                         .WithAll<EnemyComponent>()
                         .WithEntityAccess())
            {
                aspect.Move(SystemAPI.Time.DeltaTime);

                if (aspect.Position.y <= setup.MinY)
                    entitiesToRemove.Add(entity);
            }
            
            foreach (var entity in entitiesToRemove)
            {
                state.EntityManager.RemoveComponent<MovementSpeedComponent>(entity);
            }

            entitiesToRemove.Dispose();
        }
    }
}