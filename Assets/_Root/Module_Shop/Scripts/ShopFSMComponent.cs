using UnityEngine;

public class ShopFSMComponent : MonoBehaviour
{
    public ShopFSMManager manager;
    public ShopItemList shopItemList;
    public SwordSkinSO swordSkinSO;
    public bool isMockData;
    public RectTransform contentShop;
    public TMPro.TMP_Text txtShopAmountCoin;

    public CurrencyData currency = new CurrencyData();
    public SkinData skinData = new SkinData();
    public ShopItem curSelectedItem;
}
