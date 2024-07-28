using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Pooling
{
    public class GenericObjectPooler<T> where T : MonoBehaviour
    {
        private T prefab;
        private Queue<T> objectPool = new Queue<T>();
        private int poolSize;
        private bool allowDynamicExpansion = true;

        public GenericObjectPooler(T prefab, int initialPoolSize, bool allowDynamicExpansion = true)
        {
            this.prefab = prefab;
            this.poolSize = initialPoolSize;
            this.allowDynamicExpansion = allowDynamicExpansion;

            // Initialize the pool with initial objects
            for (int i = 0; i < initialPoolSize; i++)
            {
                T obj = Object.Instantiate(prefab);
                obj.gameObject.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }

        public T Get()
        {
            if (objectPool.Count == 0)
            {
                if (allowDynamicExpansion)
                {
                    T obj = Object.Instantiate(prefab);
                    obj.gameObject.SetActive(false);
                    Debug.LogWarning("Object pool expanded dynamically.");
                    return obj;
                }
                else
                {
                    Debug.LogWarning("Object pool is empty and dynamic expansion is not allowed.");
                    return null;
                }
            }

            T objToReturn = objectPool.Dequeue();
            objToReturn.gameObject.SetActive(true);
            return objToReturn;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            objectPool.Enqueue(obj);
        }

        public void Clear()
        {
            while (objectPool.Count > 0)
            {
                T obj = objectPool.Dequeue();
                Object.Destroy(obj.gameObject);
            }
        }

        public void SetDynamicExpansion(bool allowExpansion)
        {
            this.allowDynamicExpansion = allowExpansion;
        }
    }
}