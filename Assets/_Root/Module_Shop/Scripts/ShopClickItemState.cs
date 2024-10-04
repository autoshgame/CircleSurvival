using UnityEngine;
using AutoShGame.Base.FSMState;
using System.Collections;
using AutoShGame.Base.Observer;
using AutoShGame.Base.ServiceProvider;

public class ShopClickItemState : FSMState
{
    private ShopFSMDependency dependency;
    private ShopItemData itemClick;

    private IDataService dataService;
    private IDataService DataService
    {
        get 
        {
            if (dataService == null)
            {
                dataService = ServiceProvider.Resolve<IDataService>();
            }
            return dataService;
        }
    }

    public override string GetState()
    {
        return ShopEvent.CLICK_TIEM;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as ShopFSMDependency;
    }

    public override void OnEnter(object data)
    {
        itemClick = data as ShopItemData;

        PlayerData playerData = DataService.GetUserData();

        if (itemClick.itemState == ShopItemState.SELECTED)
        {
            dependency.component.manager.ChangeState(ShopEvent.VIEW);

        }
        else if (itemClick.itemState == ShopItemState.OWNED && itemClick.itemState != ShopItemState.SELECTED)
        {
            //Set selected for component
            playerData.weapon.currentSword = itemClick.skin;
            OnReselectedComponent();
        }
        else
        {
            if (playerData.currency.coin < itemClick.price)
            {
                dependency.component.manager.ChangeState(ShopEvent.VIEW);
            }
            else if (playerData.currency.coin >= itemClick.price)
            {
                playerData.currency.coin -= itemClick.price;
                playerData.weapon.currentSword = itemClick.skin;
                playerData.weapon.availableSword.Add(itemClick.skin);
                DataService.SaveUserData(playerData);
                OnReselectedComponent();
            }
        }
    }

    public void OnReselectedComponent()
    {
        ShopItem newItem = dependency.component.shopItemList.ShopItems.Find((item) => item.ShopItemData.itemID.Equals(itemClick.itemID));
        newItem.SetItemState(ShopItemState.SELECTED);
        dependency.component.curSelectedItem.SetItemState(ShopItemState.OWNED);
        dependency.component.curSelectedItem = newItem;
        dependency.component.manager.ChangeState(ShopEvent.VIEW);
    }

}
