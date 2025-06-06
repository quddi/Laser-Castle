using Unity.Entities;

namespace Code.DOTS
{
    public struct AtlasAnimationStateComponent : IComponentData
    {
        public int CurrentFrameIndex;
    }
}