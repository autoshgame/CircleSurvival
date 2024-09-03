using UnityEngine;
using AutoShGame.Base.FSMState;
using AutoShGame.Base.Sound;
using AutoShGame.Base.Observer;

public class SwordV2 : BaseWeaponV2, ICollidable
{
    [SerializeField] private SpriteRenderer swordSprite;
    [SerializeField] private CapsuleCollider2D baseCollider;
    [SerializeField] private RotateV2 rotateV2;
    [SerializeField] private Transform targetRotate;

    [SerializeField] private AudioClip hitAudio;

    //Hard Code + Ram management
    [Header("Scriptable Object")]
    [SerializeField] private SwordSO swordSO;
    [SerializeField] private SwordSkinSO swordSkinSO;

    private SwordV2Data swordV2Data;
    private Transform followObject;

    private IWeaponNotify notify;

    private void Update()
    {
        if (followObject != null)
        {
            transform.position = followObject.position;
        }
    }

    public override void Init<T>(T args)
    {
        swordV2Data = args as SwordV2Data;

        baseCollider.offset = swordSkinSO.props[swordV2Data.sword].offsetCollider;
        baseCollider.size = swordSkinSO.props[swordV2Data.sword].sizeCollider;
        swordSprite.sprite = swordSkinSO.props[swordV2Data.sword].image;
        followObject = swordV2Data.parents;
        notify = swordV2Data.notify;

        rotateV2.SetRotationTarget(targetRotate);
        rotateV2.SetRotationSpeed(swordSO.props[swordV2Data.currentLevel].rotateSpeed);
        transform.localScale = swordSO.props[swordV2Data.currentLevel].scale;
        rotateV2.SetRotateStatus(true);
    }

    public override void SetLevel(int level)
    {
        rotateV2.SetRotationSpeed(swordSO.props[level].rotateSpeed);
        transform.localScale = swordSO.props[level].scale;
    }

    public void OnCollisionDetection()
    {
        SoundTopic soundTopic = new SoundTopic(hitAudio, transform.position, SourceConfigType.ThreeD);
        Observer.Instance.NotifyObservers(soundTopic);
        rotateV2.ReverseRotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision thing
        ICollidable collisionObject = collision.gameObject.GetComponent<ICollidable>();
        if (collisionObject != null)
        {
            collisionObject.OnCollisionDetection();
        }

        //Damage thing
        IDamageable damageObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageObject != null)
        {
            damageObject.TakeDamage(12);

            if (notify != null)
            {
                notify.OnNotify(WeaponNotifyMesssage.KILL_ENEMY);
            }
        }
    }

    public override void SetStatus(bool status)
    {
        rotateV2.SetRotateStatus(status);
    }
}


public class SwordV2Data
{
    public SwordEnum sword;
    public Transform parents;
    public IWeaponNotify notify;
    public int currentLevel;
}
