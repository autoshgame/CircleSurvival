using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Pooling
{
    public class PoolUser : MonoBehaviour
    {
        [SerializeField] private ObjectPoolManager poolManager;

        public TestPool prefabToPool;
        public int amountToPool = 10; // Initial amount to pool
        private GenericObjectPooler<TestPool> gameObjectPooler;

        void Awake()
        {
            // Get the object pooler for GameObjects with specified parameters
            poolManager.CreatePool<TestPool>(prefabToPool, amountToPool);
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10f);
            poolManager.RemovePool<TestPool>();
        }
    }
}
