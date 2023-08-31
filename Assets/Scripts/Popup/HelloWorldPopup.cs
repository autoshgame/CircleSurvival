using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HelloWorldPopup : BasePopup
{
    [SerializeField] private Text dynamicText;
    [SerializeField] private Button closeButton;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private void Start()
    {
        startPos = rect.anchoredPosition3D;
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
        closeButton.onClick.AddListener(Close);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
    }

    public override void Close()
    {
        rect.DOAnchorPos3D(startPos, 0.8f).SetUpdate(true);
        Time.timeScale = 1;    
    }
}


