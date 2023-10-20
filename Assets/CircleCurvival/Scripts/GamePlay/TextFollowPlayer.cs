using UnityEngine;

public class TextFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}
