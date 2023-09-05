using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WinPopup : BasePopup
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI txtCoin;

    private WinPopupData data;

    private void Start()
    {
        homeButton.onClick.AddListener(BackToHome);
        restartButton.onClick.AddListener(Restart);
    }

    public override void Show()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
        StartCoroutine(IShowCoin(data.coinReceived));
    }

    public override BasePopup InitData<T>(T args)
    {
        WinPopupData data = args as WinPopupData;
        this.data = data;
        return base.InitData(args);
    }

    public void BackToHome()
    {
        Time.timeScale = 1;
        GameSceneManager.Instance.LoadHome();
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
public class WinPopupData
{
    public int coinReceived;

    public WinPopupData(int coinReceived)
    {
        this.coinReceived = coinReceived;
    }
}
