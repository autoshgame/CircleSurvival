using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : BaseMenu
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Button settingButton;

    public FixedJoystick Joystick { get => joystick; set => joystick = value; }

    private void Start()
    {
        settingButton.onClick.AddListener(ShowSettingPopup);    
    }

    public void ShowSettingPopup()
    {
        SingletonUI.Instance.Push(Popup.PausePopup);
        Time.timeScale = 0;
    }
}
