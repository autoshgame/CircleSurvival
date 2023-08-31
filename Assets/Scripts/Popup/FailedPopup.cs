using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FailedPopup : BasePopup
{
    [SerializeField] private Button homeButton;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private void Start()
    {
        startPos = rect.anchoredPosition3D;
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);

        homeButton.onClick.AddListener(BackToHome);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
    }

    public void BackToHome()
    {
        GameSceneManager.Instance.LoadHome();
        Time.timeScale = 1;
        rect.DOAnchorPos3D(startPos, 0.8f).SetUpdate(true);
    }
}
