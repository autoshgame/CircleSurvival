using AutoShGame.Base.Modal;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LoseModal : BaseModal
{
    [SerializeField] private Button btnExit;
    [SerializeField] private RectTransform content;

    private LoseModalData loseModalData;

    private void Start()
    {
        btnExit.onClick.AddListener(Exit);
    }

    public override BaseModal InitData<T>(T args)
    {
        loseModalData = args as LoseModalData;
        return base.InitData(args);
    }

    public override void Show()
    {
        content.DOScale(Vector2.one, 0.3f).SetEase(Ease.Flash);
    }

    private void Exit()
    {
        loseModalData.actionClickExit?.Invoke();
        Destroy(this.gameObject);
    }
}

public class LoseModalData
{
    public Action actionClickExit;
}

