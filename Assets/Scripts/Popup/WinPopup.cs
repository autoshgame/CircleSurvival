using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinPopup : BasePopup
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private void Start()
    {
        Time.timeScale = 0;
        startPos = rect.anchoredPosition3D;
        rect.DOAnchorPos3D(endPos, 0.8f).SetUpdate(true);
        homeButton.onClick.AddListener(BackToHome);
        restartButton.onClick.AddListener(Restart);
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

    public void Restart()
    {
        GameSceneManager.Instance.LoadGamePlay();
        Time.timeScale = 1;
        rect.DOAnchorPos3D(startPos, 0.8f).SetUpdate(true);
    }
}
