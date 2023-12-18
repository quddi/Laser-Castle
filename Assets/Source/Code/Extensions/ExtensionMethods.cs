using System.Collections.Generic;

namespace Code.Extensions
{
    public static class ExtensionMethods
    {
        public static T2 GetValue<T1, T2>(this Dictionary<T1, T2> dictionary, T1 key) 
            where T2 : class
        {
            return dictionary.ContainsKey(key)
                ? dictionary[key]
                : null;
        }
    }
}