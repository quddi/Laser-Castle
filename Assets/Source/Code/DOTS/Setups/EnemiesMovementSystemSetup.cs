using System;
using Unity.Entities;

namespace Code.DOTS
{
    public struct EnemiesMovementSystemSetup : IComponentData
    {
        public float MinY;
    }
}