using UnityEngine.UI;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private ScreenInfo screenInfo;

    void Start()
    {
        btn.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        SoundManager.Instance.PlayAudioOneShot(SoundUtils.BUTTON_CLICK);
    }
}


public enum ScreenInfo {
    MainScreen,
    SPL, 
    HomeScene,
    NavigatorScene,
    DebugScene,
    ShopScene,
}