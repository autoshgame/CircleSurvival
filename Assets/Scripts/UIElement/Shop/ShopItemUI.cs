using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private SwordEnum sword;
    [SerializeField] private SwordSkinSO swordSkinSO;
    [SerializeField] private TextMeshProUGUI selectedTxt;
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] private Image image;
    [SerializeField] private Button btnBuy;

    private void Start()
    {
        btnBuy.onClick.AddListener(BuySkin);    
    }

    public void Init(SwordEnum sword, string text, Sprite image, bool owned = false, bool selected = false)
    {
        this.sword = sword;
        moneyTxt.text = text;
        this.image.sprite = image;

        if (owned == true) 
        {
            moneyTxt.gameObject.SetActive(false);
        } 
        else 
        {
            moneyTxt.gameObject.SetActive(true);
        }

        if (selected == true)
        {
            selectedTxt.gameObject.SetActive(true);
        }
        else
        {
            selectedTxt.gameObject.SetActive(false);
        }
    }

    public void HideSelected()
    {
        this.selectedTxt.gameObject.SetActive(false);
    }

    void BuySkin()
    {
        if (GameData.Instance.GetUserData().currentSword == this.sword)
        {
            return;
        }

        if (GameData.Instance.GetUserData().availableSword.Contains(this.sword))
        {
            GameData.Instance.SelectSwordSkin(sword);
        }
        else
        {
            if (GameData.Instance.GetUserData().coin > swordSkinSO.props[this.sword].coin)
            {
                GameData.Instance.SetCoin(GameData.Instance.GetUserData().coin - swordSkinSO.props[this.sword].coin);
                ((ShopPopup)SingletonUI.Instance.Get(Popup.ShopPopup)).UpdateMoney();
                GameData.Instance.SelectSwordSkin(sword);
                GameData.Instance.AddSwordSkin(sword);
            }
            else
            {
                return;
            }
        }

        moneyTxt.gameObject.SetActive(false);
        selectedTxt.gameObject.SetActive(true);
        ((ShopPopup)SingletonUI.Instance.Get(Popup.ShopPopup)).ItemSelected.HideSelected();
        ((ShopPopup)SingletonUI.Instance.Get(Popup.ShopPopup)).ItemSelected = this;
    }
}
