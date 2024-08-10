using System.Collections.Generic;
using UnityEngine;

public class ShopItemList : MonoBehaviour
{
    [SerializeField] private RectTransform rectContentShop;
    [SerializeField] private ShopItem shopItemPrefab;

    private List<ShopItem> shopItems = new List<ShopItem>();
    public List<ShopItem> ShopItems { get => shopItems; }

    public void Init(List<ShopItemData> data)
    {
        for (int i = 0; i < data.Count; ++i)
        {
            ShopItem item = Instantiate(shopItemPrefab, rectContentShop);
            item.Init(data[i]);
            shopItems.Add(item);
        }
    }
}
