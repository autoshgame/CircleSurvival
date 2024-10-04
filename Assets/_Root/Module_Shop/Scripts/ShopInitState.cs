using AutoShGame.Base.FSMState;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using AutoShGame.Base.ServiceProvider;

public class ShopInitState : FSMState
{
    private ShopFSMDependency dependency;

    public override string GetState()
    {
        return ShopEvent.INIT;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as ShopFSMDependency;    
    }

    public override void OnEnter()
    {
        dependency.component.contentShop.transform.DOScale(Vector3.zero, 0);
        StartCoroutine(InitShop());
    }

    IEnumerator InitShop()
    {
        var userData = ServiceProvider.Resolve<IDataService>().GetUserData();
        dependency.component.txtShopAmountCoin.text = userData.currency.coin.ToString();

        dependency.component.contentShop.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.Flash);
        yield return new WaitForSeconds(0.3f);

        List<ShopItemData> shopItemDatas = new List<ShopItemData>();

        int indexDataItemId = 0;
        int indexChoosenSword = 0;

        foreach (var item in dependency.component.swordSkinSO.props)
        {
            ShopItemData data = new ShopItemData();

            data.itemID = indexDataItemId;         
            data.Image = item.Value.image;
            data.price = item.Value.coin;
            data.skin = item.Key;

            if (userData.weapon.availableSword.Contains(item.Key))
            {
                data.itemState = ShopItemState.OWNED;
            }
            else
            {
                data.itemState = ShopItemState.NOT_BOUGHT;
            }

            if (userData.weapon.currentSword == item.Key)
            {
                data.itemState = ShopItemState.SELECTED;
                indexChoosenSword = indexDataItemId;
            }

            shopItemDatas.Add(data);
            indexDataItemId++;
        }

        dependency.component.shopItemList.Init(shopItemDatas);

        dependency.component.curSelectedItem = dependency.component.shopItemList.ShopItems[indexChoosenSword];
        dependency.component.manager.ChangeState(ShopEvent.VIEW);
    }
}

