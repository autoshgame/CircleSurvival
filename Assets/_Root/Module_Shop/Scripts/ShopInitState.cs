using AutoShGame.Base.FSMState;
using UnityEngine;
using AutoShGame.Base.Observer;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;

public class ShopInitState : FSMState
{
    private bool isLoadCurrencyDataSuccess;
    private bool isLoadSkinDataSuccess;

    [SerializeField] private bool isMockData;

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
        //Load currency data (coin)
        CurrencyDataTopic testGameDataTopic = new CurrencyDataTopic();
        testGameDataTopic.result = (value) => {
            dependency.component.currency.coin = value.coin;
        };

        testGameDataTopic.actionType = ActionType.GET;
        testGameDataTopic.onLoadSuccess = (value) => { isLoadCurrencyDataSuccess = value; };
        ObserverAutoSh.NotifyObservers(testGameDataTopic);
        //end load currency data

        //Load skin data
        SkinDataTopic skinDataTopic = new SkinDataTopic();
        skinDataTopic.result = (value) => {
            dependency.component.skinData.ownedSwords = value.ownedSwords;
            dependency.component.skinData.choosenSword = value.choosenSword;
        };

        skinDataTopic.actionType = ActionType.GET;
        skinDataTopic.onLoadSuccess = (value) => { isLoadSkinDataSuccess = value; };
        ObserverAutoSh.NotifyObservers(skinDataTopic);
        //end load skin data

        yield return new WaitUntil(() => isLoadCurrencyDataSuccess && isLoadSkinDataSuccess);

        dependency.component.txtShopAmountCoin.text = dependency.component.currency.coin.ToString();

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

            if (dependency.component.skinData.ownedSwords.Contains(item.Key))
            {
                data.itemState = ShopItemState.OWNED;
            }
            else
            {
                data.itemState = ShopItemState.NOT_BOUGHT;
            }

            if (dependency.component.skinData.choosenSword == item.Key)
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

