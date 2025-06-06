using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Enemies
{
    [CreateAssetMenu(menuName = "Configs/Enemies/Enemy Config", fileName = "Enemy config")]
    public class EnemyConfig : SerializedScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public Vector3 MovementSpeed { get; private set; }

        [field: SerializeField] public EnemyType Type { get; private set; }

        [field: SerializeField] public AnimatorOverrideController AnimatorOverrideController { get; private set; }

        [field: SerializeField] public GameObject Prefab { get; private set; }

        [field: SerializeField] public float AnimationFrameDuration { get; private set; }

        [field: SerializeField] public int AnimationFramesCount { get; private set; }
    }
}