using System.Collections.Generic;
using UnityEngine;
using AutoShGame.Base.MonoSingleton;
using AutoShGame.Base.Observer;

namespace AutoShGame.Base.Pooling
{
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        private Dictionary<System.Type, object> poolDictionary = new Dictionary<System.Type, object>();

        public GenericObjectPooler<T> CreatePool<T>(T prefab, int amountToPool) where T : MonoBehaviour
        {
            System.Type type = typeof(T);

            if (!poolDictionary.ContainsKey(type))
            {
                poolDictionary[type] = new GenericObjectPooler<T>(prefab, amountToPool);
            }

            return (GenericObjectPooler<T>)poolDictionary[type];
        }

        public GenericObjectPooler<T> GetPool<T>() where T : MonoBehaviour
        {
            System.Type type = typeof(T);

            if (poolDictionary.ContainsKey(type))
            {
                return (GenericObjectPooler<T>)poolDictionary[type];
            }

            Debug.LogError("NO POOL AVAILABLE");
            return null;
        }

        public void RemovePool<T>() where T : MonoBehaviour
        {
            System.Type type = typeof(T);

            if (poolDictionary.ContainsKey(type))
            {
                // Optionally clean up pooled objects before removing the pool
                // Example:
                // var pooler = (GenericObjectPooler<T>)poolDictionary[type];
                // pooler.Clear(); // Implement Clear() method in GenericObjectPooler if needed

                var pooler = (GenericObjectPooler<T>)poolDictionary[type];
                pooler.Clear();
                poolDictionary.Remove(type);
            }
            else
            {
                Debug.LogWarning($"No pool of type {typeof(T)} found to remove.");
            }
        }
    }
}