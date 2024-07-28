using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject objectToRotate;
    [SerializeField] private bool rotateClockwise = true;
    [SerializeField] private float rotationSpeed = 30f; 
    [SerializeField] private bool canRotate = true;

    private void Start()
    {
        float randomRotationAngle = Random.Range(0, 360);
        transform.Rotate(Vector3.forward, randomRotationAngle);
    }

    void Update()
    {
        if (canRotate)
        {
            float rotationDirection = rotateClockwise ? 1f : -1f;
            objectToRotate.transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime * Vector3.forward);
        }
    }

    public void ReverseRotate()
    {
        rotateClockwise = !rotateClockwise;
    }

    public void StopRotate()
    {
        canRotate = false;
    }

    public void UpdateRotateSpeed(float value)
    {
        rotationSpeed = value;
    }
}