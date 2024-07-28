using UnityEngine;

public class SPLController : MonoBehaviour
{
    void Start()
    {
        GameData.Instance.LoadUserData();
        GameSceneManager.Instance.LoadHome();
    }
}
