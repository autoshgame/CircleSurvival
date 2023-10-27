using DG.Tweening;
using UnityEngine;
using System;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private DateTime timeStartSpin;
    [SerializeField] private DateTime timeEndSpin;
    [SerializeField] private bool canSpin = true;

    private void Start()
    {
        timeStartSpin = DateTime.Now;
    }

    private void Update()
    {
        if (canSpin == true)
        {
            if ((DateTime.Now - timeStartSpin).TotalSeconds < 7)
            {
                rotationSpeed = (float)(DateTime.Now - timeStartSpin).TotalSeconds * 100;
            }
            else 
            {
                rotationSpeed = 700;
            }
            timeEndSpin = DateTime.Now;
        }
        else
        {
            if ((DateTime.Now - timeEndSpin).TotalSeconds < 7)
            {
                rotationSpeed = (7 - (float)(DateTime.Now - timeEndSpin).TotalSeconds) * 100;
            }
            else
            {
                rotationSpeed = 0;
            }
            
        }

        this.transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
    }
}
