using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Observer;

public class ShopViewState : FSMState, IObservableAutoSh<ShopViewStateTopic>
{
    private ShopFSMDependency dependency;

    public override string GetState()
    {
        return ShopEvent.VIEW;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as ShopFSMDependency;
    }

    public override void OnEnter()
    {
        ObserverAutoSh.RegisterObserver(this);
    }

    public override void OnExit()
    {
        ObserverAutoSh.RemoveObserver(this);
    }

    private void OnDestroy()
    {
        ObserverAutoSh.RemoveObserver(this);
    }

    public void OnObserverNotify(ShopViewStateTopic data)
    {
        switch (data.Action)
        {
            case ShopViewStateTopicAction.CLICK_ITEM:
                dependency.component.manager.ChangeState(ShopEvent.CLICK_TIEM, data.itemData);
                break;
        }
    }


}

public class ShopViewStateTopic
{
    public string Action;
    public ShopItemData itemData;
}

public static class ShopViewStateTopicAction
{
    public const string CLICK_ITEM = "CLICK_ITEM";
}