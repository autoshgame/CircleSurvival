using UnityEngine;
using AutoShGame.Base.FSMState;
using System.Collections;
using AutoShGame.Base.Observer;
using System.Linq;

public class ShopClickItemState : FSMState
{
    private ShopFSMDependency dependency;
    private ShopItemData itemClick;

    bool isUpdateCurrencyDataSuccess = false;
    bool isUpdateSkinDataSuccess = false;

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

        if (itemClick.itemState == ShopItemState.SELECTED)
        {
            dependency.component.manager.ChangeState(ShopEvent.VIEW);

        }
        else if (itemClick.itemState == ShopItemState.OWNED && itemClick.itemState != ShopItemState.SELECTED)
        {
            //Set selected for component
            dependency.component.skinData.choosenSword = itemClick.skin;

            StartCoroutine(UpdateSelectedSkin());
        }
        else
        {
            if (dependency.component.currency.coin < itemClick.price)
            {
                dependency.component.manager.ChangeState(ShopEvent.VIEW);
            }
            else if (dependency.component.currency.coin >= itemClick.price)
            {
                dependency.component.currency.coin = dependency.component.currency.coin - itemClick.price;
                dependency.component.skinData.choosenSword = itemClick.skin;
                dependency.component.skinData.ownedSwords.Add(itemClick.skin);
               
                StartCoroutine(UpdateCurrency());
            }
        }
    }

    IEnumerator UpdateCurrency()
    {
        CurrencyDataTopic topic = new CurrencyDataTopic();
        topic.actionType = ActionType.UPDATE;
        topic.updateData = dependency.component.currency;
        topic.onLoadSuccess = (value) => isUpdateCurrencyDataSuccess = value;
        Observer.Instance.NotifyObservers(topic);

        SkinDataTopic skinDataTopic = new SkinDataTopic();
        skinDataTopic.actionType = ActionType.UPDATE;
        skinDataTopic.updateData = dependency.component.skinData;
        skinDataTopic.onLoadSuccess = (value) => isUpdateSkinDataSuccess = value;
        Observer.Instance.NotifyObservers(skinDataTopic);

        yield return new WaitUntil(() => (isUpdateCurrencyDataSuccess && isUpdateSkinDataSuccess));

        dependency.component.txtShopAmountCoin.text = dependency.component.currency.coin.ToString();

        OnReselectedComponent();
    }

    IEnumerator UpdateSelectedSkin()
    {
        isUpdateSkinDataSuccess = false;

        SkinDataTopic skinDataTopic = new SkinDataTopic();
        skinDataTopic.actionType = ActionType.UPDATE;
        skinDataTopic.updateData = dependency.component.skinData;
        skinDataTopic.onLoadSuccess = (value) => isUpdateSkinDataSuccess = value;
        Observer.Instance.NotifyObservers(skinDataTopic);

        yield return new WaitUntil(() => (isUpdateSkinDataSuccess));

        OnReselectedComponent();
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
