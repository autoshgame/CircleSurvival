using UnityEngine.UI;
using UnityEngine;

public class ShopTest : MonoBehaviour
{
    [SerializeField] private Button shopBtn;
    [SerializeField] private ShopFSMComponent component;

    // Start is called before the first frame update
    void Start()
    {
        shopBtn.onClick.AddListener(ShowShop);
    }

    void ShowShop()
    {
        component.manager.gameObject.SetActive(true);
        component.manager.ChangeState(ShopEvent.INIT);
    }
}
