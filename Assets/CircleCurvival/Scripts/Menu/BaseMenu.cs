using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    public RectTransform rect;

    public virtual BaseMenu InitData<T>(T args)
    {
        return this;
    }

    public virtual void Show()
    {
    }

    public virtual void Close()
    {

    }
}
