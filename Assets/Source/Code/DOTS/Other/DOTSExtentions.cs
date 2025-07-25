using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Code.DOTS
{
    public static class DOTSExtentions
    {
        public static T Random<T>(this NativeList<T> list) where T : unmanaged
        {
            return list[UnityEngine.Random.Range(0, list.Length)];
        }

        public static T Random<T>(this DynamicBuffer<T> buffer) where T : unmanaged
        {
            return buffer[UnityEngine.Random.Range(0, buffer.Length)];
        }

        public static SpriteRenderer GetEnemySpriteRenderer(this Entity enemy, EntityManager entityManager)
        {
            var children = entityManager.GetBuffer<Child>(enemy);

            return entityManager.GetComponentObject<SpriteRenderer>(children[0].Value);
        }
    }
}