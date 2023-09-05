using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TMPro;

public class FailedPopup : BasePopup
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI txtCoin;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private LosePopupData data;

    private void Start()
    {
        startPos = rect.anchoredPosition3D;
        homeButton.onClick.AddListener(BackToHome);
        restartButton.onClick.AddListener(Restart);
    }

    public override void Show()
    {
        StartCoroutine(IShow());
    }

    IEnumerator IShow()
    {
        this.gameObject.SetActive(true);
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
        yield return new WaitForSecondsRealtime(0.8f);
        if (data.canReceiveCoin)
        {
            StartCoroutine(IShowCoin(data.coinReceived));
        }
    }

    public override BasePopup InitData<T>(T args)
    {
        LosePopupData data = args as LosePopupData;
        this.data = data;
        return base.InitData(args);
    }

    public void BackToHome()
    {
        GameSceneManager.Instance.LoadHome();
        Time.timeScale = 1;
        rect.DOAnchorPos3D(startPos, 0.8f).SetUpdate(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GameSceneManager.Instance.LoadGamePlay();
    }

    IEnumerator IShowCoin(int coinReceived)
    {
        int tempCoin = 0;

        while (tempCoin < coinReceived)
        {
            tempCoin++;
            txtCoin.text = tempCoin.ToString();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}

[System.Serializable]
public class LosePopupData
{
    public bool canReceiveCoin;
    public int coinReceived;

    public LosePopupData(bool canReceiveCoin, int coinReceived)
    {
        this.canReceiveCoin = canReceiveCoin;
        this.coinReceived = coinReceived;
    }
}
