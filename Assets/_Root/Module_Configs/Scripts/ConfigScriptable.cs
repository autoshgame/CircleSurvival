using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/GlobalConfig", order = 1)]
public class ConfigScriptable : ScriptableObject
{
    [SerializeField] private bool turnOnMockService;
    public bool TurnOnMockService { get => turnOnMockService; set => turnOnMockService = value; }
}
