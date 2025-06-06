using Unity.Entities;

namespace Code.DOTS
{
    public struct AtlasAnimationComponent : IComponentData
    {
        public int FramesCount;
        public float FrameDuration;
    }
}