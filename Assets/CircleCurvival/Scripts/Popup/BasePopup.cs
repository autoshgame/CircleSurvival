using UnityEngine;
using DG.Tweening;

public class BasePopup : MonoBehaviour
{
    public RectTransform rect;

    public virtual BasePopup InitData<T>(T args) {
        return this;
    }

    public virtual void Show() { 
    }

    public virtual void Close()
    {

    }
}
