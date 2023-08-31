using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawnController : Singleton<BotSpawnController>
{
    [SerializeField] private List<Bot> aliveBots;
    [SerializeField] private List<Bot> deadBots;
    
    [SerializeField] private HashSet<Vector3> alreadySpawnPos = new HashSet<Vector3>();

    float xMaxPositive = 0;
    float xMinPositive = 0;
    float xMaxNegative = 0;
    float xMinNegative = 0;

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
                    int randomIndex = 0;
                    int botSpawm = totalBotCanSpawn;
                    for (int i = 0; i < botSpawm; ++i)
                    {
                        if (deadBots.Count > 0)
                        {
                            randomIndex = Random.Range(0, deadBots.Count);
                            Bot bot = deadBots[randomIndex];
                            int level = BaseGameManager.Instance.player.Level - 2 > 0 ? BaseGameManager.Instance.player.Level - 2 : 0;
                            int randomLevelSpawn = Random.Range(level, level + 4);
                            bot.SetLevel(randomLevelSpawn);
                            bot.SetSwordLevel(randomLevelSpawn);
                            bot.SetSwordSkin(SwordEnum.SWORD_6);

                            float yMax = BaseGameManager.Instance.player.transform.position.y + 9;
                            float yMin = BaseGameManager.Instance.player.transform.position.y - 9;
                            xMaxPositive = BaseGameManager.Instance.player.transform.position.x + 15;
                            xMinPositive = BaseGameManager.Instance.player.transform.position.x + 8;
                           xMaxNegative = BaseGameManager.Instance.player.transform.position.x - 8;
                            xMinNegative = BaseGameManager.Instance.player.transform.position.x - 15;

                            float xSpawn = 0;
                            float ySpawn = Random.Range(yMin, yMax);
                            int option = Random.Range(0, 2);

                            if (option == 1)
                            {
                                xSpawn = Random.Range(xMinNegative, xMaxNegative);
                            } 
                            else
                            {
                                xSpawn = Random.Range(xMinPositive, xMaxPositive);
                            }
                            Vector3 pos = new Vector3(xSpawn, ySpawn, 0);
                            if (!alreadySpawnPos.Contains(pos) && pos != BaseGameManager.Instance.player.transform.position)
                            {
                                alreadySpawnPos.Add(pos);
                                bot.Revive(pos);
                                alreadySpawnPos.Remove(pos);
                            }
                        }
                    }
                    
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}


[System.Serializable]
public class MapsBounds
{
    public float positiveX;
    public float positiveY;
    public float negativeX;
    public float negativeY;
}