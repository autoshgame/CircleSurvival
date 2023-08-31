using UnityEngine;
using System.Collections.Generic;

public class SingletonUI: Singleton<SingletonUI>
{ 
    [SerializeField] private Canvas baseCanvas;

    [SerializeField] private CanvasSO canvasSO;

    private Dictionary<Popup, BasePopup> availablePopups = new Dictionary<Popup, BasePopup>();
    private Dictionary<Menu, BaseMenu> availableMenus = new Dictionary<Menu, BaseMenu>();

    public BasePopup Push(Popup popup)
    {
        if (availablePopups.ContainsKey(popup))
        {
            availablePopups[popup].Show();
            return availablePopups[popup];
        }
        else
        {
            GameObject ele = Instantiate(canvasSO.popups[popup].gameObject, baseCanvas.transform);
            BasePopup data = ele.GetComponent<BasePopup>();
            availablePopups.Add(popup, data);
            return data;
        }
    }

    public BasePopup Get(Popup popup)
    {
        if (availablePopups.ContainsKey(popup))
        {
            return availablePopups[popup];
        }

        Debug.LogError("WARNING , POPUP " + popup.ToString() + " DONT EXSISTS");
        return null;
    }

    public BaseMenu Push(Menu menu)
    {
        if (availableMenus.ContainsKey(menu))
        {
            availableMenus[menu].gameObject.SetActive(true);
            return availableMenus[menu];
        }
        else
        {
            GameObject ele = Instantiate(canvasSO.menus[menu].gameObject, baseCanvas.transform);
            BaseMenu data = ele.GetComponent<BaseMenu>();
            availableMenus.Add(menu, data);
            return data;
        }
    }

    public BaseMenu Get(Menu menu)
    {
        if (availableMenus.ContainsKey(menu))
        {
            return availableMenus[menu];
        }

        Debug.LogError("WARNING , MENU " + menu.ToString() + " DONT EXSISTS");
        return null;
    }

    public void PopAll()
    {
        foreach (var item in availablePopups)
        {
            Pop(item.Value.gameObject);
        }

        foreach (var item in availableMenus)
        {
            Pop(item.Value.gameObject);
        }
    }

    public void Pop(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
