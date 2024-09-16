using UnityEngine;
using DG.Tweening;
using AutoShGame.Base.Modal;
using UnityEngine.UI;
using AutoShGame.Base.Sound;
using AutoShGame.Base.Observer;
using UnityEngine.SceneManagement;

public class InGameSettingsModal : BaseModal
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private RectTransform content;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button homeButton;

    private void Awake()
    {
        content.transform.localScale = Vector3.zero;
        closeButton.onClick.AddListener(Close);
        homeButton.onClick.AddListener(GoToHome);
    }

    private void Start()
    {
        soundSlider.onValueChanged.AddListener(OnSliderValueChanged);
        soundSlider.value = PlayerPrefs.GetFloat(Constant.KEY_CONFIG_VOLUME, 1f);
    }

    public override void Show()
    {
        content.DOScale(Vector3.one, 0.1f).SetEase(Ease.Flash).OnComplete(() => Time.timeScale = 0);
    }

    public override void Close()
    {
        Time.timeScale = 1;
        content.DOScale(Vector3.zero, 0.2f).SetEase(Ease.Flash).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }

    void GoToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat(Constant.KEY_CONFIG_VOLUME, value);
        SoundGlobalConfigTopic globalConfigTopic = new SoundGlobalConfigTopic(value);
        ObserverAutoSh.NotifyObservers(globalConfigTopic);
    }
}
