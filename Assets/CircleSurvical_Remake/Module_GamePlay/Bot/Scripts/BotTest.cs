using System.Collections.Generic;
using UnityEngine;
using AutoShGame.Base.Observer;
using System.Collections;

public class BotTest : MonoBehaviour, IObservableAutoSh<BotDeadStateChannel>, IObservableAutoSh<BotReviveStateChannel>
{
    private List<Transform> bots = new List<Transform>();
    private HashSet<Vector3> alreadySpawnPos = new HashSet<Vector3>();

    private List<BotFSMManager> listBotAlive = new List<BotFSMManager>();
    private List<BotFSMManager> listBotDead = new List<BotFSMManager>();

    [SerializeField] private List<BotFSMManager> botFSMManager;
    [SerializeField] private List<SwordEnum> randomSword;

    private Transform targetSpawnTransform;
    private PlayerFSMComponent playerFSMComponent;

    int randomIndex = 0;
    int randomLevelSpawn = 0;

    float xMaxPositive = 0;
    float xMinPositive = 0;
    float xMaxNegative = 0;
    float xMinNegative = 0;
    float xSpawn = 0;
    float ySpawn = 0;

    Vector3 posSpawn;

    private void Awake()
    {
        //Init();
    }

    private void OnEnable()
    {
        Observer.Instance.RegisterObserver<BotDeadStateChannel>(this);
        Observer.Instance.RegisterObserver<BotReviveStateChannel>(this);
    }

    private void OnDisable()
    {
        Observer.Instance?.RemoveObserver<BotDeadStateChannel>(this);
        Observer.Instance?.RemoveObserver<BotReviveStateChannel>(this);
    }

    public void OnObserverNotify(BotDeadStateChannel data)
    {
        listBotAlive.Remove(data.deadBot);
        listBotDead.Add(data.deadBot);
    }

    public void OnObserverNotify(BotReviveStateChannel data)
    {
        listBotAlive.Add(data.aliveBot);
        listBotDead.Remove(data.aliveBot);
    }

    public void StartSpawnBot()
    {
        StartCoroutine(SpawnBot(3f));
    }

    private IEnumerator SpawnBot(float delay)
    {
        while (true)
        {
            if (listBotAlive.Count < 7)
            {
                int totalBotCanSpawn = 7 - listBotAlive.Count;

                for (int i = 0; i < totalBotCanSpawn; ++i)
                {
                    if (listBotDead.Count > 0)
                    {
                        randomIndex = Random.Range(0, listBotDead.Count);

                        int level = 0;
                        randomLevelSpawn = Random.Range(level, level + 4);
                        randomIndex = Random.Range(0, randomSword.Count);
                        randomIndex = Random.Range(0, listBotDead.Count);

                        BotFSMManager botManager = listBotDead[randomIndex];

                        botManager.transform.localScale = Vector3.zero;

                        BotReviveStateData botReviveStateData = new BotReviveStateData();
                        botReviveStateData.levelRevive = Random.Range(playerFSMComponent.stat.level, playerFSMComponent.stat.level + 2);
                        botReviveStateData.swordSkin = SwordEnum.SWORD_1;

                        Debug.Log(targetSpawnTransform.position);

                        float yMax = targetSpawnTransform.position.y + 9;
                        float yMin = targetSpawnTransform.position.y - 9;
                        xMaxPositive = targetSpawnTransform.position.x + 15;
                        xMinPositive = targetSpawnTransform.position.x + 8;
                        xMaxNegative = targetSpawnTransform.position.x - 8;
                        xMinNegative = targetSpawnTransform.position.x - 15;

                        Debug.Log($"xMaxPositive {xMaxPositive} xMinPositive {xMinPositive} yMax {yMax} yMin {yMin}");

                        int option = Random.Range(0, 2);
                        xSpawn = option == 1 ? Random.Range(xMinNegative, xMaxNegative) : Random.Range(xMinPositive, xMaxPositive);
                        ySpawn = Random.Range(yMin, yMax);

                        posSpawn = new Vector3(xSpawn, ySpawn, 0);

                        if (!alreadySpawnPos.Contains(posSpawn))
                        {
                            alreadySpawnPos.Add(posSpawn);
                            botReviveStateData.positionSpawn = posSpawn;
                            alreadySpawnPos.Remove(posSpawn);
                        }

                        botManager.ChangeState(BotEvent.REVIVE, botReviveStateData);

                        listBotDead.Remove(botManager);
                        listBotAlive.Add(botManager);
                    }
                }
            }

            yield return new WaitForSeconds(delay);
        }
    }

    public void OnRequestTargerTransform(Transform target)
    {
        this.targetSpawnTransform = target;
    }

    public void OnRequestPlayerFSM(PlayerFSMComponent target)
    {
        playerFSMComponent = target;
    }

    public void Init()
    {
        for (int i = 0; i < botFSMManager.Count; ++i)
        {
            var component = botFSMManager[i].GetComponent<BotFSMComponent>();

            bots.Add(component.botRigidbody2D.transform);
        }

        for (int i = 0; i < botFSMManager.Count; ++i)
        {
            var component = botFSMManager[i].GetComponent<BotFSMComponent>();

            if (component != null)
            {
                component.enemyDetection.OnRequestOtherBotPost(bots);
                component.enemyDetection.OnRequestPlayerPos(targetSpawnTransform);
            }

            listBotAlive.Add(component.manager);
        }
    }
}
