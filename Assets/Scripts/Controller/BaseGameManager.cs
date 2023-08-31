public class BaseGameManager : Singleton<BaseGameManager>
{
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
        gameState = GameState.Lose;
        SingletonUI.Instance.Push(Popup.LosePopup);
    }
}


public enum GameState
{
    Win,
    Lose, 
    Paused,
    Playing,
}