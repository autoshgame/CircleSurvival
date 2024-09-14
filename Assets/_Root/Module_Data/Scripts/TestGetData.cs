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
        CurrencyData group = new CurrencyData();

        bool isLoadSuccess = false;

        CurrencyDataTopic testGameDataTopic = new CurrencyDataTopic();

        testGameDataTopic.result = (value) => { 
            group.coin = value.coin; 
        };
        
        testGameDataTopic.actionType = ActionType.GET;
        testGameDataTopic.onLoadSuccess = (value) => { isLoadSuccess = value; };
        Observer.Instance.NotifyObservers(testGameDataTopic);

        yield return new WaitUntil(() => isLoadSuccess == true);

        Debug.Log($"GET DATA : {group.coin}");
    }
}
