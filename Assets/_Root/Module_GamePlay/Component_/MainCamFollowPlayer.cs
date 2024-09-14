using UnityEngine;

public class MainCamFollowPlayer : MonoBehaviour
{
    public Transform TargetFollow { get; set; }
    private bool isFollow = false;

    Vector3 positionFollow;

    // Update is called once per frame
    void Update()
    {
        if (isFollow == false) return;
        if (TargetFollow == null) return;
        if (!TargetFollow.gameObject.activeInHierarchy) return;

        positionFollow.x = TargetFollow.transform.position.x;
        positionFollow.y = TargetFollow.transform.position.y;
        positionFollow.z = transform.position.z;

        transform.position = positionFollow;
    }

    public void SetFollowStatus(bool status)
    {
        isFollow = status;
    }
}
