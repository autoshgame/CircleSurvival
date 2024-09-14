using UnityEngine;
using UnityEngine.UI;

public class ShopItemXButton : MonoBehaviour
{
    [SerializeField] private Button xButton;
    [SerializeField] private ShopFSMComponent component;

    void Start()
    {
        xButton.onClick.AddListener(DisableShop);
    }

    void DisableShop()
    {
        component.manager.ChangeState(ShopEvent.CLOSE);
    }
}

