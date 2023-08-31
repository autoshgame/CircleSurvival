using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPLController : MonoBehaviour
{
    void Start()
    {
        GameData.Instance.LoadUserData();
        GameSceneManager.Instance.LoadHome();
    }
}
