using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Code.Extensions
{
    public static class ExtensionMethods
    {
        public static float NextFloat(this System.Random random, float min, float max)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 127));
            return (float)(mantissa * exponent);
        }
        
#if UNITY_EDITOR
        public static IEnumerable<T> GetAllScriptableObjects<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            
            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                
                yield return AssetDatabase.LoadAssetAtPath<T>(path);
            }
        }
        
        public static IEnumerable GetAllScriptableObjects(Type type)
        {
            string[] guids = AssetDatabase.FindAssets("t:" + type.Name);
            
            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                
                yield return AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            }
        }

        public static T GetAsset<T>(string assetName) where T : UnityEngine.Object
        {
            var filter = $"t:{typeof(T).Name} {assetName}";
            
            string[] guids = AssetDatabase.FindAssets(filter);
            
            string path = AssetDatabase.GUIDToAssetPath(guids.First());
            
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        public static string GetAssetPathWithoutItsName<T>(T asset) where T : UnityEngine.Object
        {
            var fullPath = AssetDatabase.GetAssetPath(asset);
            var fileExtension = ".asset";

            return fullPath.Substring(0, fullPath.Length - (asset.name.Length + fileExtension.Length));
        }
#endif
    }
}