using UnityEngine;
using System;
using AutoShGame.Base.Observer;
using System.Collections.Generic;
using System.Collections;

public class TestGetData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        yield return null;
    }
}
