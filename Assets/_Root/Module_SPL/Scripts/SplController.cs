using UnityEngine.SceneManagement;
using UnityEngine;

public class SplController : MonoBehaviour
{
    [SerializeField] private ServiceProviderImpl impl;

    void Start()
    {
        impl.InstallBindings();
        SceneManager.LoadScene("Home");
    }
}
