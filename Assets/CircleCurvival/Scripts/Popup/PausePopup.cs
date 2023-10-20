using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PausePopup : BasePopup
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Slider slider;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private void Start()
    {
        startPos = rect.anchoredPosition3D;
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
        slider.value = GameData.Instance.GetUserData().sliderValue;
        SoundManager.Instance.HandleAudioVolumeChange(Mathf.Log10(slider.value) * 20);

        closeButton.onClick.AddListener(Close);
        homeButton.onClick.AddListener(BackToHome);
        slider.onValueChanged.AddListener((value) => HandleAudioChange(value));
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
    }

    public override void Close()
    {
        rect.DOAnchorPos3D(startPos, 0.8f).SetUpdate(true);
        Time.timeScale = 1;
    }

    public void BackToHome()
    {
        GameSceneManager.Instance.LoadHome();
        Time.timeScale = 1;
        rect.DOAnchorPos3D(startPos, 0.8f).SetUpdate(true);
    }

    public void HandleAudioChange(float value)
    {
        SoundManager.Instance.HandleAudioVolumeChange(Mathf.Log10(value) * 20);
        UserData data = GameData.Instance.GetUserData();
        data.sliderValue = value;
        GameData.Instance.SaveUserData(data);
    }
}
