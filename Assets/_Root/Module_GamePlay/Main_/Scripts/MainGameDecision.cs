using UnityEngine;
using AutoShGame.Base.Observer;

public class MainGameDecision : MonoBehaviour
    , IObservableAutoSh<PlayerUpdateLevelTopic>
    , IObservableAutoSh<PlayerDeadStateTopic>
{
    public int playerWinLevel;

    private int curPlayerLevel;

    private void OnEnable()
    {
        Observer.Instance?.RegisterObserver<PlayerUpdateLevelTopic>(this);
        Observer.Instance?.RegisterObserver<PlayerDeadStateTopic>(this);
    }

    private void OnDisable()
    {
        Observer.Instance?.RemoveObserver<PlayerUpdateLevelTopic>(this);
        Observer.Instance?.RemoveObserver<PlayerDeadStateTopic>(this);
    }

    public void OnObserverNotify(PlayerUpdateLevelTopic data)
    {
        curPlayerLevel = data.level;

        if (curPlayerLevel > playerWinLevel)
        {
            MainGamePlayTopic mainGamePlayTopic = new MainGamePlayTopic();
            mainGamePlayTopic.action = MainGamePlayTopicAction.WIN_GAME;
            Observer.Instance.NotifyObservers(mainGamePlayTopic);
        }
    }

    public void OnObserverNotify(PlayerDeadStateTopic data)
    {
        MainGamePlayTopic mainGamePlayTopic = new MainGamePlayTopic();
        mainGamePlayTopic.action = MainGamePlayTopicAction.LOSE_GAME;
        Observer.Instance.NotifyObservers(mainGamePlayTopic);
    }
}
