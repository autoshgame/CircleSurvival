using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopup : BasePopup
{
    [SerializeField] private SwordSkinSO swordSkinSO;
    [SerializeField] private RectTransform listShopSkinRect;
    [SerializeField] private ShopItemUI shopItemUI;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(Close);
        InitShopUI();
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        InitShopUI();
    }

    public override void Close()
    {
        this.gameObject.SetActive(false);
    }

    void InitShopUI()
    {
        for (int i = listShopSkinRect.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(listShopSkinRect.transform.GetChild(i).gameObject);
        }

        foreach (KeyValuePair<SwordEnum, SwordProps> entry in swordSkinSO.props)
        {
            GameObject item = Instantiate(shopItemUI.gameObject, listShopSkinRect.transform);
            bool ownSkin = GameData.Instance.GetUserData().availableSword.Contains(entry.Key);
            bool isSelected = GameData.Instance.GetUserData().currentSword == entry.Key;
            item.GetComponent<ShopItemUI>().Init(entry.Key, entry.Value.coin.ToString(), entry.Value.image, ownSkin, isSelected);
        }
    }
}
