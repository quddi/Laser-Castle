using Unity.Entities;
using UnityEngine;

namespace Code.DOTS
{
    public readonly partial struct AtlasAnimationAspect : IAspect
    {
        public readonly RefRW<AnimationTimeComponent> AnimationTime;
        public readonly RefRW<AtlasAnimationStateComponent> AtlasAnimationState;
        public readonly RefRO<AtlasAnimationComponent> AtlasAnimation;

        public bool AddTime(float deltaTime)
        {
            AnimationTime.ValueRW.Time += deltaTime;

            if (!(AnimationTime.ValueRO.Time >= AtlasAnimation.ValueRO.FrameDuration))
                return false;
            
            AnimationTime.ValueRW.Time -= AtlasAnimation.ValueRO.FrameDuration;

            var currentFrameIndex = AtlasAnimationState.ValueRO.CurrentFrameIndex;
            var framesCount = AtlasAnimation.ValueRO.FramesCount;
            
            AtlasAnimationState.ValueRW.CurrentFrameIndex = (currentFrameIndex + 1) % framesCount;
            
            return true;
        }
    }
}