using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code.Extensions;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Code.Enemies
{
    [CreateAssetMenu(menuName = "Configs/Enemies/Enemies Config", fileName = "Enemies config")]
    public class EnemiesConfig : SerializedScriptableObject
    {
        [field: SerializeField] public HashSet<EnemyConfig> EnemiesConfigs { get; private set; } = new();
        
#if UNITY_EDITOR
        public static IEnumerable EnemiesIds => ExtensionMethods.GetAllScriptableObjects<EnemiesConfig>()
            .First()
            .EnemiesConfigs
            .Select(config => config.Id);
        
        [Button]
        private void CollectAllConfigs()
        {
            var configs = ExtensionMethods.GetAllScriptableObjects<EnemyConfig>().ToHashSet();

            var enemiesConfig = ExtensionMethods.GetAllScriptableObjects<EnemiesConfig>()
                .First();
            
            enemiesConfig.EnemiesConfigs = configs;
            
            EditorUtility.SetDirty(enemiesConfig);
        }
#endif
    }
}