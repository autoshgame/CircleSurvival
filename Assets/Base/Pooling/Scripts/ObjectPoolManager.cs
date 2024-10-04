using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Pooling
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private Dictionary<string, object> poolDictionary = new Dictionary<string, object>();

        public GenericObjectPooler<T> CreatePool<T>(string key, T prefab, int amountToPool) where T : MonoBehaviour
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("Pool key cannot be null or empty.");
                return null;
            }

            if (poolDictionary.ContainsKey(key))
            {
                Debug.LogWarning($"Pool with key '{key}' already exists. Returning existing pool.");
                return (GenericObjectPooler<T>)poolDictionary[key];
            }

            var pooler = new GenericObjectPooler<T>(prefab, amountToPool);
            poolDictionary[key] = pooler;
            return pooler;
        }

        public GenericObjectPooler<T> GetPool<T>(string key) where T : MonoBehaviour
        {
            if (poolDictionary.TryGetValue(key, out var pool))
            {
                return (GenericObjectPooler<T>)pool;
            }

            Debug.LogError($"No pool available with key '{key}'.");
            return null;
        }

        public void RemovePool<T>(string key) where T : MonoBehaviour
        {
            if (poolDictionary.TryGetValue(key, out var pool))
            {
                var pooler = (GenericObjectPooler<T>)pool;
                pooler.Clear();
                poolDictionary.Remove(key);
            }
            else
            {
                Debug.LogWarning($"No pool with key '{key}' found to remove.");
            }
        }
    }
}