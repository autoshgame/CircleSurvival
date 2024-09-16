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
        ObserverAutoSh.RegisterObserver<PlayerUpdateLevelTopic>(this);
        ObserverAutoSh.RegisterObserver<PlayerDeadStateTopic>(this);
    }

    private void OnDisable()
    {
        ObserverAutoSh.RemoveObserver<PlayerUpdateLevelTopic>(this);
        ObserverAutoSh.RemoveObserver<PlayerDeadStateTopic>(this);
    }

    public void OnObserverNotify(PlayerUpdateLevelTopic data)
    {
        curPlayerLevel = data.level;

        if (curPlayerLevel > playerWinLevel)
        {
            MainGamePlayTopic mainGamePlayTopic = new MainGamePlayTopic();
            mainGamePlayTopic.action = MainGamePlayTopicAction.WIN_GAME;
            ObserverAutoSh.NotifyObservers(mainGamePlayTopic);
        }
    }

    public void OnObserverNotify(PlayerDeadStateTopic data)
    {
        MainGamePlayTopic mainGamePlayTopic = new MainGamePlayTopic();
        mainGamePlayTopic.action = MainGamePlayTopicAction.LOSE_GAME;
        ObserverAutoSh.NotifyObservers(mainGamePlayTopic);
    }
}
