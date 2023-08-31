using UnityEngine;
using System.Collections;

public class Bot : Player
{
    [SerializeField] private Player targetPlayer;
    private float reverseDir = 1;

    Vector3 direction = new Vector3(0, 0, 0);

    private void Awake()
    {
        humanState = HumanState.ALIVE;
    }

    private void Start()
    {
        ScanPlayer();
    }

    void Update()
    {
        if (humanState != HumanState.DEAD)
        {
            if (targetPlayer != null && targetPlayer.gameObject.activeInHierarchy && this.GetInstanceID() != targetPlayer.GetInstanceID())
            {
                if (Vector2.Distance(this.transform.position, targetPlayer.transform.position) > 2f)
                {
                    direction = (targetPlayer.transform.position - this.transform.position).normalized;
                } 
                else
                {
                    direction = Vector3.zero;
                }
            } 
            else
            {
                ScanPlayer();
                reverseDir = 1;
            }

            direction = new Vector3(direction.x * reverseDir, direction.y * reverseDir, direction.z);

            if (direction != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                humanRigidbody2d.velocity = moveSpeed * Time.deltaTime * new Vector2(direction.x, direction.y);
            }
            else
            {
                humanRigidbody2d.velocity = Vector2.zero;
            }
        }
    }

    void ScanPlayer()
    {
        if (BaseGameManager.Instance.gameState == GameState.Playing)
        {
            float distance = Vector2.Distance(this.transform.position, BotSpawnController.Instance.AliveBots[0].transform.position);
            int foundIndex = 0;
            for (int i = 0; i < BotSpawnController.Instance.AliveBots.Count; ++i)
            {
                if (BotSpawnController.Instance.AliveBots[i].GetInstanceID() != this.GetInstanceID())
                {
                    float currentDistance = Vector2.Distance(this.transform.position, BotSpawnController.Instance.AliveBots[i].transform.position);
                    if (currentDistance <= distance)
                    {
                        distance = currentDistance;
                        foundIndex = i;
                    }
                }
            }

            float distancePlayer = Vector2.Distance(this.transform.position, BaseGameManager.Instance.player.transform.position);

            if (distancePlayer <= distance)
            {
                targetPlayer = BaseGameManager.Instance.player;
            } else
            {
                targetPlayer = BotSpawnController.Instance.AliveBots[foundIndex];
            }
        }
        
    }

    public override void Revive(Vector2 revivePos)
    {
        BotSpawnController.Instance.RemoveDeadBots(this);
        BotSpawnController.Instance.AddAliveBots(this);
        base.Revive(revivePos);
    }
    
    public override void Dead()
    {
        BotSpawnController.Instance.RemoveAliveBot(this);
        BotSpawnController.Instance.AddDeadBots(this);
        base.Dead();
    }

    public void SetLevel(int level)
    {
        this.Level = level;
    }

    public void SetSwordLevel(int level)
    {
        sword.SetLevel(level);
    }

    public void SetSwordSkin(SwordEnum swordEnum)
    {
        sword.InitSword(swordEnum);
    }

    public void ReverseDirection()
    {
        StartCoroutine(IReverseDirection());
    }

    IEnumerator IReverseDirection()
    {
        reverseDir = -1;
        yield return new WaitForSeconds(1.5f);
        reverseDir = 1;
    }
}
