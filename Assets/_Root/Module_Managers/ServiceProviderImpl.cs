using UnityEngine;
using AutoShGame.Base.ServiceProvider;

public class ServiceProviderImpl : MonoBehaviour
{
    [SerializeField] private ModalSerivce modalSerivce;
    [SerializeField] private SoundService soundService;
    [SerializeField] private PlayerDataManager dataService;

    public void InstallBindings()
    {
        ServiceProvider.Register<IModalService>(modalSerivce);
        ServiceProvider.Register<ISoundService>(soundService);
        ServiceProvider.Register<IDataService>(dataService);
    }
}
