using UnityEngine;
using AutoShGame.Base.ServiceProvider;

public class FakeManagers : MonoBehaviour
{
    [SerializeField] private ConfigScriptable config;
    [SerializeField] private ModalSerivce modalSerivce;
    [SerializeField] private SoundService soundService;

    private void Awake()
    {
        if (!config.TurnOnMockService)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            ServiceProvider.Register<IModalService>(modalSerivce);
            ServiceProvider.Register<ISoundService>(soundService);
        }
    }
}
