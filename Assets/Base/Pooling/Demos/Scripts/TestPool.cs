using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoShGame.Base.Pooling
{
    public class TestPool : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDisable()
        {
            ObjectPoolManager.Instance.GetPool<TestPool>().ReturnToPool(this);
        }
    }
}
