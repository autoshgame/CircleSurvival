using UnityEngine;

public class BotFSMComponent : MonoBehaviour
{
    public BaseWeaponV2 weapon;
    public TMPro.TMP_Text txtLevel;
    public Rigidbody2D botRigidbody2D;
    public BotFSMManager manager;
    public BotEnemyDetection enemyDetection;
    public BotMovement botMovement;
    public BotStat botStat;
    public BotOutSystemDetection botOutSystemDetection;
}
