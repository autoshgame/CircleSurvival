using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeManagers : MonoBehaviour
{
    [SerializeField] private ConfigScriptable config;

    private void Awake()
    {
        if (!config.TurnOnMockService)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
