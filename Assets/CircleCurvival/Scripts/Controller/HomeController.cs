using AutoShGame.Base.MonoSingleton;

public class HomeController : Singleton<HomeController>
{
    void Start()
    {
        SingletonUI.Instance.Push(Menu.HomeMenu);
    }
}

