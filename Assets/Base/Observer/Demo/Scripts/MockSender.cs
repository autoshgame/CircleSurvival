using System.Collections;
using System.Collections.Generic;
using AutoShGame.Base.Observer;
using UnityEngine;

public class MockSender : MonoBehaviour
{
    void Start()
    {
        MockChannel channelData = new MockChannel();
        channelData.message = "HELLO WORLD";
        ObserverAutoSh.NotifyObservers(channelData);
    }
}

[System.Serializable]
public class MockSenderData
{
    public int id;
}
