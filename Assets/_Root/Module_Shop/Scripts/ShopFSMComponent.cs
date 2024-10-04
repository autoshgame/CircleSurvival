using UnityEngine;

public class ShopFSMComponent : MonoBehaviour
{
    public ShopFSMManager manager;
    public ShopItemList shopItemList;
    public SwordSkinSO swordSkinSO;
    public RectTransform contentShop;
    public TMPro.TMP_Text txtShopAmountCoin;
    public ShopItem curSelectedItem;
}
