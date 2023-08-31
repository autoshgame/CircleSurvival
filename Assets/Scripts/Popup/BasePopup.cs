using UnityEngine;
using DG.Tweening;

public class BasePopup : MonoBehaviour
{
    public RectTransform rect;

    public virtual void InitData<T>(T args) { 
    }

    public virtual void Show() { 
    }

    public virtual void Close()
    {

    }
}
