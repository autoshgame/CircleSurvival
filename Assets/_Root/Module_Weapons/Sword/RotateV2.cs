using UnityEngine;

public class RotateV2 : MonoBehaviour
{
    private bool canRotate;
    private bool rotateClockwise = true;

    private float rotationSpeed = 30f;

    private Transform targetRotate;

    void Update()
    {
        if (canRotate)
        {
            float rotationDirection = rotateClockwise ? 1f : -1f;
            targetRotate.Rotate(rotationDirection * rotationSpeed * Time.deltaTime * Vector3.forward);
        }
    }

    public void ReverseRotate()
    {
        rotateClockwise = !rotateClockwise;
    }

    public void SetRotationTarget(Transform target)
    {
        targetRotate = target;
    }

    public void SetRotateStatus(bool status)
    {
        canRotate = status;
    }    

    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}
