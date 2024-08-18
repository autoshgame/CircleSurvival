using AutoShGame.Base.Modal;
using UnityEngine;
using UnityEngine.UI;
using AutoShGame.Base.Observer;
using DG.Tweening;

public class LoseModal : BaseModal
{
    [SerializeField] private Button btnExit;
    [SerializeField] private RectTransform content;

    private void Start()
    {
        btnExit.onClick.AddListener(Exit);
    }

    public override void Show()
    {
        content.DOScale(Vector2.one, 0.3f).SetEase(Ease.Flash);
    }

    private void Exit()
    {
        LoseModalActionTopic loseModalActionTopic = new LoseModalActionTopic();
        loseModalActionTopic.actionLoseModal = ActionLoseModal.CLOSE;
        Observer.Instance.NotifyObservers(loseModalActionTopic);
    }
}

//Action
public class LoseModalActionTopic
{
    public ActionLoseModal actionLoseModal;
}

public enum ActionLoseModal
{
    CLOSE
}
