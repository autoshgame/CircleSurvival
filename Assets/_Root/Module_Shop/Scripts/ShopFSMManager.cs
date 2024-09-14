using UnityEngine;
using AutoShGame.Base.FSMState;

public class ShopFSMManager : FSMManager
{
    private FSMState shopInitState;
    private FSMState shopViewState;
    private FSMState shopClickItemState;
    private FSMState shopCloseState;

    protected override void Awake()
    {
        base.Awake();

        ShopFSMComponent component = GetComponent<ShopFSMComponent>();

        ShopFSMDependency shopFSMDependency = new ShopFSMDependency();
        shopFSMDependency.component = component;

        shopInitState = GetComponent<ShopInitState>();
        dicState.Add(shopInitState.GetState(), shopInitState);
        shopInitState.OnSetupDependency(shopFSMDependency);

        shopViewState = GetComponent<ShopViewState>();
        dicState.Add(shopViewState.GetState(), shopViewState);
        shopViewState.OnSetupDependency(shopFSMDependency);

        shopClickItemState = GetComponent<ShopClickItemState>();
        dicState.Add(shopClickItemState.GetState(), shopClickItemState);
        shopClickItemState.OnSetupDependency(shopFSMDependency);

        shopCloseState = GetComponent<ShopCloseState>();
        dicState.Add(shopCloseState.GetState(), shopCloseState);
        shopCloseState.OnSetupDependency(shopFSMDependency);
    }

    private void Start()
    {
        //ChangeState(ShopEvent.INIT);
    }
}

public class ShopFSMDependency
{
    public ShopFSMComponent component;
}
