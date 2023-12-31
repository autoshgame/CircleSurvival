using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;

public class ShopPopup : BasePopup
{
    [SerializeField] private SwordSkinSO swordSkinSO;
    [SerializeField] private RectTransform listShopSkinRect;
    [SerializeField] private ShopItemUI shopItemUI;
    [SerializeField] private Button closeButton;
    [SerializeField] private ShopItemUI itemSelected;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private AudioSource audioSource;

    public ShopItemUI ItemSelected { get => itemSelected; set => itemSelected = value; }

    private void Start()
    {
        closeButton.onClick.AddListener(Close);
    }

    public override void Show()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
        InitShopUI();
        UpdateMoney();
    }

    public override void Close()
    {
        StartCoroutine(IClose());
    }

    IEnumerator IClose()
    {
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InOutSine);
        yield return new WaitForSecondsRealtime(0.3f);
        Destroy(this.gameObject);
    }

    public void UpdateMoney()
    {
        coins.text = $"COINS : {GameData.Instance.GetUserData().coin}";
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
            ShopItemUI itemUI = item.GetComponent<ShopItemUI>();
            itemUI.Init(entry.Key, entry.Value.coin.ToString(), entry.Value.image, ownSkin, isSelected);

            if (isSelected == true)
            {
                itemSelected = itemUI;
            }
        }
    }
}
