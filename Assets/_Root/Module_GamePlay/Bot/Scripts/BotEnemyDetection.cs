using System.Collections.Generic;
using UnityEngine;

public class BotEnemyDetection : MonoBehaviour
{
    private Transform player;
    private List<Transform> listCurBot;
    int foundIndex = 0;

    private Transform target;
    public Transform Target { get => target; }

    float distance = 10000000;

    public void ScanPlayer()
    {
        if (listCurBot == null) return;

        if (listCurBot.Count == 0) return;

        for (int i = 0; i < listCurBot.Count; ++i)
        {
            if (listCurBot[i].gameObject.GetInstanceID() != this.gameObject.GetInstanceID() && listCurBot[i].gameObject.activeInHierarchy)
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

        int randomRedirectToPlayer = Random.Range(0, 4);

        if ((randomRedirectToPlayer == 0) || (distancePlayer <= distance + 3) && player != null && player.gameObject.transform.localScale != Vector3.zero)
        {
            target = player;
        }
        else
        {
            if (listCurBot[foundIndex].gameObject.activeInHierarchy)
            {
                target = listCurBot[foundIndex];
            }
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
