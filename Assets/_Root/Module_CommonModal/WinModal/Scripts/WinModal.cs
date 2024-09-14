using UnityEngine;
using AutoShGame.Base.Modal;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WinModal : BaseModal
{
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnReplay;
    [SerializeField] private RectTransform content;
    [SerializeField] private TMPro.TMP_Text txtCoim;

    private WinModalData winModalData;

    private void Start()
    {
        btnExit.onClick.AddListener(Exit);
        btnReplay.onClick.AddListener(Replay);
    }

    public override BaseModal InitData<T>(T args)
    {
        winModalData = args as WinModalData;
        return base.InitData(args);
    }

    public override void Show()
    {
        txtCoim.text = $"COINS : {winModalData.coinReceived}";
        content.DOScale(Vector2.one, 0.3f).SetEase(Ease.Flash);
    }

    private void Exit()
    {
        winModalData.actionExit?.Invoke();
        Destroy(this.gameObject);
    }

    private void Replay()
    {
        winModalData.actionReplay?.Invoke();
        Destroy(this.gameObject);
    }
}

public class WinModalData
{
    public Action actionExit;
    public Action actionReplay;
    public int coinReceived;
}
