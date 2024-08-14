﻿using Unity.Entities;
using UnityEngine;

namespace Source.DOTS
{
    public partial class EnemiesSpawnSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<EnemiesConfigsContainerComponent>();
        }

        protected override void OnUpdate()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            
            var configsComponent = SystemAPI.GetSingleton<EnemiesConfigsContainerComponent>();
            var buffer = EntityManager.GetBuffer<LinkedEntityGroup>(configsComponent.Value);
            
            var randomConfig = buffer.Random().Value;
            var entityComponent = EntityManager.GetComponentData<EntityComponent>(randomConfig);
            
            EntityManager.Instantiate(entityComponent.Value);
        }
    }
}