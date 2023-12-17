using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Loading
{
    [CreateAssetMenu(menuName = "Configs/Loading/Loading Config", fileName = "Loading config")]
    public class LoadingConfig : SerializedScriptableObject
    {
        [SerializeField] private readonly HashSet<string> _scenesNames = new();

#if UNITY_EDITOR
        [ValueDropdown("GetScenesNames"), Tooltip("Fill scene names first!")]
#endif
        [SerializeField] private readonly HashSet<string> _baseScenesNames = new();
        
#if UNITY_EDITOR
        [ValueDropdown("GetScenesNames"), Tooltip("Fill scene names first!")]
#endif
        [SerializeField] private readonly string _gameSceneName;

        public HashSet<string> ScenesNames => _scenesNames;

        public HashSet<string> BaseScenesNames => _baseScenesNames;

        public string GameSceneName => _gameSceneName;

#if UNITY_EDITOR
        private static LoadingConfig _instance;

        public static IEnumerable GetScenesNames()
        {
            if (_instance == null)
            {
                var assets = UnityEditor.AssetDatabase.FindAssets($"t:{nameof(LoadingConfig)}");

                if (assets.Length > 0)
                {
                    _instance = assets.Select(UnityEditor.AssetDatabase.GUIDToAssetPath)
                        .Select(UnityEditor.AssetDatabase.LoadAssetAtPath<LoadingConfig>).First();
                }
            }

            return _instance.ScenesNames;
        }
#endif
    }
}