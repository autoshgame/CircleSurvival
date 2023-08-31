using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[CreateAssetMenu(fileName ="CanvasAsset", menuName ="Base/CanvasAsset", order =1)]
public class CanvasSO : ScriptableObject
{
    public SerializableDictionaryBase<Popup, BasePopup> popups;
    public SerializableDictionaryBase<Menu, BaseMenu> menus;
}

public enum Popup
{
    Test,
    LosePopup,
    PausePopup,
    WinPopup,
}

public enum Menu
{
    GamePlayMenu,
    HomeMenu
}