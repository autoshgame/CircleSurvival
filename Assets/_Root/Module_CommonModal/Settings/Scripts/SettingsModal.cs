using UnityEngine;
using AutoShGame.Base.Modal;
using UnityEngine.UI;
using DG.Tweening;
using AutoShGame.Base.Sound;
using AutoShGame.Base.Observer;

public class SettingsModal : BaseModal
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private RectTransform content;

    [SerializeField] private Button closeButton;

    private void Awake()
    {
        content.transform.localScale = Vector3.zero;
        closeButton.onClick.AddListener(Close);
    }

    private void Start()
    {
        soundSlider.onValueChanged.AddListener(OnSliderValueChanged);
        soundSlider.value = PlayerPrefs.GetFloat(Constant.KEY_CONFIG_VOLUME, 1f);
    }

    public override void Show()
    {
        content.DOScale(Vector3.one, 0.2f).SetEase(Ease.Flash);
    }

    public override void Close()
    {
        content.DOScale(Vector3.zero, 0.2f).SetEase(Ease.Flash).OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }

    void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat(Constant.KEY_CONFIG_VOLUME, value);
        SoundGlobalConfigTopic globalConfigTopic = new SoundGlobalConfigTopic(value);
        ObserverAutoSh.NotifyObservers(globalConfigTopic);
    }
}


