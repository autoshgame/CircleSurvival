using UnityEngine;

public class PlayerFSMComponent : MonoBehaviour
{
    public PlayerMovement movement;
    public FixedJoystick joyStick;
    public Rigidbody2D playerRigidbody2D;
    public PlayerFSMManager manager;
    public BaseWeaponV2 weapon;
    public PlayerStat stat;
    public TMPro.TMP_Text txtLevel;
    public PlayerOutSystemDetection playerOutSystemDetection;

    public AudioClip audioUpgradeLevel;
}
