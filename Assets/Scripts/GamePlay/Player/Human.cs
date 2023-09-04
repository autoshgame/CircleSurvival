using UnityEngine;


public class Human : Player
{
    [SerializeField] private FixedJoystick joystick;

    Vector3 joystickDir = Vector3.zero;

    private void Awake()
    {
        humanState = HumanState.ALIVE;
    }

    protected override void Start()
    {
        base.Start();
        sword.InitSword(GameData.Instance.GetUserData().currentSword);
    }

    void Update()
    {
        if (humanState != HumanState.DEAD) {
            if (joystick != null)
            {
                joystickDir = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

                if (joystickDir != Vector3.zero)
                {
                    float targetAngle = Mathf.Atan2(joystickDir.x, joystickDir.z) * Mathf.Rad2Deg;
                    Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    humanRigidbody2d.velocity = moveSpeed * Time.deltaTime * new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
                }
                else
                {
                    humanRigidbody2d.velocity = Vector2.zero;
                }
            }
        }
    }

    public void SetJoyStick(FixedJoystick joystick)
    {
        this.joystick = joystick;
    }

    public override void Dead()
    {
        base.Dead();
        BaseGameManager.Instance.EndGame();
    }

    public override void UpdateLevel()
    {
        base.UpdateLevel();
        if (level == 18)
        {
            SingletonUI.Instance.Push(Popup.WinPopup);
        }
    }
}

