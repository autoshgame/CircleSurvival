using UnityEngine.SceneManagement;
using AutoShGame.Base.MonoSingleton;
public class GameSceneManager : Singleton<GameSceneManager>
{
    public void LoadGamePlay()
    {
        SingletonUI.Instance.PopAll();
        SceneManager.LoadScene("PlayScene");
    }
    
    public void LoadHome()
    {
        SingletonUI.Instance.PopAll();
        SceneManager.LoadScene("HomeScene");
    }
}
