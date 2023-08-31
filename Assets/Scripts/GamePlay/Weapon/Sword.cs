using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : BaseWeapon
{
    [SerializeField] private Transform human;
    [SerializeField] private int level;
    [SerializeField] private Rotate rotate;
    [SerializeField] private TriggerRotate trigger;
    [SerializeField] private SpriteRenderer swordSprite;

    [Header("Scriptable Object")]
    [SerializeField] private SwordSO swordSO;
    [SerializeField] private SwordSkinSO swordSkinSO;

    private void Awake()
    {
        level = 0;
    }

    private void Start()
    {
        SwordEnum sword = SwordEnum.SWORD_1;
        InitSword(sword);
    }

    void Update()
    {
        if (human != null) {
            this.transform.position = human.position;
        }
    }


    public void InitSword(SwordEnum sword)
    {
        swordSprite.sprite = swordSkinSO.props[sword].image;
        this.transform.localScale = swordSO.props[level].scale;
        trigger.SetColliderOffset(swordSkinSO.props[sword].offsetCollider);
        trigger.SetColliderSize(swordSkinSO.props[sword].sizeCollider);
    }

    public void SetLevel(int level)
    {
        if (level < 18)
        {
            this.level = level;
            rotate.UpdateRotateSpeed(swordSO.props[level].rotateSpeed);
            this.transform.localScale = swordSO.props[level].scale;
        }
    }

    public override void UpdateLevel()
    {
        if (level < 18)
        {
            level++;
            rotate.UpdateRotateSpeed(swordSO.props[level].rotateSpeed);
            this.transform.localScale = swordSO.props[level].scale;
        }
    }

    public override void DoRotate()
    {
        rotate.ReverseRotate();
    }
}
