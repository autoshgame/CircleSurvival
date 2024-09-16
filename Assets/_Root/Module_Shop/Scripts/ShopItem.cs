using UnityEngine;
using UnityEngine.UI;
using AutoShGame.Base.Observer;
using AutoShGame.Base.Sound;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Button btnClick;
    [SerializeField] private TMPro.TMP_Text txtState;

    [SerializeField] private AudioClip audioClick;

    private ShopItemData shopItemdata;
    public ShopItemData ShopItemData { get => shopItemdata; }

    void Start()
    {
        btnClick.onClick.AddListener(OnClickItemShop);
    }

    public void Init(ShopItemData data)
    {
        shopItemdata = data;

        this.itemImage.sprite = shopItemdata.Image;
        SetItemState(data.itemState);
    }

    public void SetItemState(ShopItemState shopItemState)
    {
        shopItemdata.itemState = shopItemState;

        switch (shopItemState)
        {
            case ShopItemState.NOT_BOUGHT:
                this.txtState.text = shopItemdata.price.ToString();
                break;
            case ShopItemState.OWNED:
                this.txtState.text = "BOUGHT";
                break;
            case ShopItemState.SELECTED:
                this.txtState.text = "SELECTED";
                break;
        }
    }

    void OnClickItemShop()
    {
        ShopViewStateTopic shopViewStateTopic = new ShopViewStateTopic();
        shopViewStateTopic.itemData = shopItemdata;
        shopViewStateTopic.Action = ShopViewStateTopicAction.CLICK_ITEM;
        ObserverAutoSh.NotifyObservers<ShopViewStateTopic>(shopViewStateTopic);
        //Event

        SoundTopic soundTopic = new SoundTopic(audioClick);
        ObserverAutoSh.NotifyObservers(soundTopic);
    }
}

public enum ShopItemState
{
    NOT_BOUGHT,
    OWNED,
    SELECTED
}

[System.Serializable]
public class ShopItemData
{
    //Use to search for item
    public int itemID;
    public SwordEnum skin;
    public Sprite Image;
    public int price;
    public ShopItemState itemState;
}



