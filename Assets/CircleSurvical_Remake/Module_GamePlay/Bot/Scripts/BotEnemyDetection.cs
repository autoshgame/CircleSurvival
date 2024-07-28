using System.Collections.Generic;
using UnityEngine;

public class BotEnemyDetection : MonoBehaviour
{
    private Transform player;
    private List<Transform> listCurBot;

    private Transform target;
    public Transform Target { get => target; }

    public void ScanPlayer()
    {
        if (listCurBot == null) return;

        if (listCurBot.Count == 0) return;

        float distance = 10000000;
        int foundIndex = 0;

        for (int i = 0; i < listCurBot.Count; ++i)
        {
            if (listCurBot[i].gameObject.GetInstanceID() != this.gameObject.GetInstanceID() && this.gameObject.activeInHierarchy)
            {
                float currentDistance = Vector2.Distance(this.transform.position, listCurBot[i].position);
                if (currentDistance <= distance)
                {
                    distance = currentDistance;
                    foundIndex = i;
                }
            }
        }

        float distancePlayer = 0;

        if (player != null)
        {
            distancePlayer = Vector2.Distance(this.transform.position, player.position);
        } 

        if (distancePlayer <= distance && player != null && player.gameObject.activeInHierarchy)
        {
            target = player;
        }
        else
        {
            target = listCurBot[foundIndex];
        }
    }

    public void OnRequestPlayerPos(Transform player)
    {
        this.player = player;
    }

    public void OnRequestOtherBotPost(List<Transform> listCurBot)
    {
        this.listCurBot = listCurBot;
    }
}
