using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("State")]
    [SerializeField] protected HumanState humanState;
    [SerializeField] private PlayerType playerType;
    [SerializeField] protected int level = 0;

    [Header("Movement")]
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float moveSpeed;

    [Header("Sword")]
    [SerializeField] protected Sword sword;

    [Header("RigidBody")]
    [SerializeField] protected Rigidbody2D humanRigidbody2d;

    [Header("Audio Source")]
    [SerializeField] protected AudioSource audioSource;

    [Header("Text Level")]
    [SerializeField] protected TextMeshPro textLvl;

    public int Level { get => level; set => level = value; }
    public PlayerType PlayerType { get => playerType; set => playerType = value; }

    protected virtual void Start()
    {
        this.textLvl.text = "0";
    }

    public virtual void Dead()
    {
        this.humanState = HumanState.DEAD;
        this.gameObject.SetActive(false);
        this.sword.gameObject.SetActive(false);
        this.textLvl.gameObject.SetActive(false);
        audioSource.PlayOneShot(SoundManager.Instance.SoundSO.props[SoundUtils.HUMAN_DEATH]);
    }

    public virtual void Revive(Vector2 revivePos)
    {
        this.humanState = HumanState.ALIVE;
        this.transform.position = revivePos;
        sword.transform.position = revivePos;
        textLvl.transform.position = revivePos + new Vector2(0, 1);
        this.textLvl.text = this.level.ToString();

        this.transform.parent.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        this.sword.gameObject.SetActive(true);
        this.textLvl.gameObject.SetActive(true);
    }

    public virtual void UpdateLevel()
    {
        if (level < BaseGameManager.Instance.winLevel)
        {
            level++;
            textLvl.text = level.ToString();
            audioSource.PlayOneShot(SoundManager.Instance.SoundSO.props[SoundUtils.HUMAN_LEVEL_UP]);
        }
    }
}

public enum HumanState
{
    DEAD = 0,
    ALIVE = 1
}

public enum PlayerType
{
    PLAYER = 0,
    BOT,
}