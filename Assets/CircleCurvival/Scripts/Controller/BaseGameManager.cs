using UnityEngine;

public class BaseGameManager : Singleton<BaseGameManager>
{
    public int maxLevelReward;
    public int winLevel;
    public GameState gameState;
    public Human player;

    private void Awake()
    {
        gameState = GameState.Playing;
    }

    private void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        BotSpawnController.Instance.StartSpawnBot();
        GamePlayUI menu = (GamePlayUI) SingletonUI.Instance.Push(Menu.GamePlayMenu);
        player.SetJoyStick(menu.Joystick);
    }

    public void EndGame()
    {
        if (gameState == GameState.Win || gameState == GameState.Paused) return;

        gameState = GameState.Lose;
        bool canReceiveCoin = false;
        int coinReceived = 0;
        if (player.Level > maxLevelReward)
        {
            GameData.Instance.SetCoin(GameData.Instance.GetUserData().coin + player.Level * 3);
            canReceiveCoin = true;
            coinReceived = player.Level * 3;
        }
        LosePopupData data = new LosePopupData(canReceiveCoin, coinReceived);
        SingletonUI.Instance.Push(Popup.LosePopup).InitData(data).Show();
    }

    public void WinGame()
    {
        if (gameState == GameState.Lose && gameState == GameState.Paused) return;

        gameState = GameState.Win;
        GameData.Instance.SetCoin(GameData.Instance.GetUserData().coin + player.Level * 3);
        WinPopupData data = new WinPopupData(player.Level * 3);
        SingletonUI.Instance.Push(Popup.WinPopup).InitData(data).Show();
    }
}


public enum GameState
{
    Win,
    Lose, 
    Paused,
    Playing,
}