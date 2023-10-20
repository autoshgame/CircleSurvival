using UnityEngine;
using UnityEngine.UI;

public class HomeMenu : BaseMenu
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingButton;

    private void Start()
    {
        playButton.onClick.AddListener(StartGame);
        settingButton.onClick.AddListener(OpenSetting);
        shopButton.onClick.AddListener(OpenShop);
        exitButton.onClick.AddListener(ExitGame);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
    }

    void StartGame()
    {
        GameSceneManager.Instance.LoadGamePlay();
    }

    void OpenSetting()
    {
        SingletonUI.Instance.Push(Popup.PausePopup);
    }

    void OpenShop()
    {
        SingletonUI.Instance.Push(Popup.ShopPopup).Show();
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
