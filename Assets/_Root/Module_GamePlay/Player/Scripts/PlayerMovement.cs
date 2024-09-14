using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private PlayerFSMComponent playerFSMComponent;

    Vector3 joystickDir = new Vector3();
    public bool CanMove { get; set; }

    private void Update()
    {
        if (CanMove == false)
        {
            playerFSMComponent.playerRigidbody2D.velocity = Vector2.zero;
            return;
        }

        joystickDir.x = playerFSMComponent.joyStick.Horizontal;
        joystickDir.z = playerFSMComponent.joyStick.Vertical;
        joystickDir.y = 0;

        if (joystickDir != Vector3.zero)
        {
            //float targetAngle = Mathf.Atan2(joystickDir.x, joystickDir.z) * Mathf.Rad2Deg;
            //Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            playerFSMComponent.playerRigidbody2D.velocity = moveSpeed * Time.deltaTime * new Vector2(playerFSMComponent.joyStick.Horizontal, playerFSMComponent.joyStick.Vertical).normalized;

            //playerFSMComponent.manager.ChangeState(PlayerState.MOVING);

        }
        else
        {
            playerFSMComponent.playerRigidbody2D.velocity = Vector2.zero;

            //playerFSMComponent.manager.ChangeState(PlayerState.IDLE);
        }
    }
}
