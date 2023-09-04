using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawnController : Singleton<BotSpawnController>
{
    [SerializeField] private List<Bot> aliveBots;
    [SerializeField] private List<Bot> deadBots;
    
    [SerializeField] private HashSet<Vector3> alreadySpawnPos = new HashSet<Vector3>();
    [SerializeField] private List<SwordEnum> randomSword;

    int randomIndex = 0;
    int randomLevelSpawn = 0;

    Vector3 posSpawn;

    float xMaxPositive = 0;
    float xMinPositive = 0;
    float xMaxNegative = 0;
    float xMinNegative = 0;
    float xSpawn = 0;
    float ySpawn = 0;

    public List<Bot> AliveBots { get => aliveBots; set => aliveBots = value; }

    public void AddAliveBots(Bot bot)
    {
        aliveBots.Add(bot);
    }

    public void RemoveAliveBot(Bot bot)
    {
        aliveBots.Remove(bot);
    }

    public void AddDeadBots(Bot bot)
    {
        deadBots.Add(bot);
    }

    public void RemoveDeadBots(Bot bot)
    {
        deadBots.Remove(bot);
    }

    public void StartSpawnBot()
    {
        StartCoroutine(SpawnBot(8f));
    }

    IEnumerator SpawnBot(float delay)
    {
        while (true)
        {
            if (BaseGameManager.Instance.gameState == GameState.Playing)
            {
                if (aliveBots.Count < 7)
                {
                    int totalBotCanSpawn = 7 - aliveBots.Count;
                    for (int i = 0; i < totalBotCanSpawn; ++i)
                    {
                        if (deadBots.Count > 0)
                        {
                            randomIndex = Random.Range(0, deadBots.Count);
                            Bot bot = deadBots[randomIndex];
                            int level = BaseGameManager.Instance.player.Level - 2 > 0 ? BaseGameManager.Instance.player.Level - 2 : 0;
                            randomLevelSpawn = Random.Range(level, level + 4);
                            randomIndex = Random.Range(0, randomSword.Count);

                            bot.SetLevel(randomLevelSpawn);
                            bot.SetSwordLevel(randomLevelSpawn);
                            bot.SetSwordSkin(randomSword[randomIndex]);

                            float yMax = BaseGameManager.Instance.player.transform.position.y + 9;
                            float yMin = BaseGameManager.Instance.player.transform.position.y - 9;
                            xMaxPositive = BaseGameManager.Instance.player.transform.position.x + 15;
                            xMinPositive = BaseGameManager.Instance.player.transform.position.x + 8;
                            xMaxNegative = BaseGameManager.Instance.player.transform.position.x - 8;
                            xMinNegative = BaseGameManager.Instance.player.transform.position.x - 15;

                            ySpawn = Random.Range(yMin, yMax);
                            int option = Random.Range(0, 2);

                            if (option == 1)
                            {
                                xSpawn = Random.Range(xMinNegative, xMaxNegative);
                            } 
                            else
                            {
                                xSpawn = Random.Range(xMinPositive, xMaxPositive);
                            }

                            posSpawn = new Vector3(xSpawn, ySpawn, 0);
                            if (!alreadySpawnPos.Contains(posSpawn) && posSpawn != BaseGameManager.Instance.player.transform.position)
                            {
                                alreadySpawnPos.Add(posSpawn);
                                bot.Revive(posSpawn);
                                alreadySpawnPos.Remove(posSpawn);
                            }
                        }
                    }
                    
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}


