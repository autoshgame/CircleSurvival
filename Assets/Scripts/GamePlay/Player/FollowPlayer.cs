using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    Vector3 rangePos = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        this.transform.position = playerPos.transform.position + rangePos;
    }
}
