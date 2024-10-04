using UnityEngine;
using AutoShGame.Base.ServiceProvider;

[DefaultExecutionOrder(-1000)]
public class FakeManagers : MonoBehaviour
{
    [SerializeField] private ConfigScriptable config;
    [SerializeField] private ModalSerivce modalSerivce;
    [SerializeField] private SoundService soundService;
    [SerializeField] private PlayerDataManager dataService;

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
            ServiceProvider.Register<IDataService>(dataService);
        }
    }
}
