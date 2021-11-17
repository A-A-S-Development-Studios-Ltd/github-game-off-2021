using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{

    public LadyBug lady;
    public Bee bee;
    public GoldLadyBug goldLadyBug;
    public GameMapper gameMap;
    public List<Bug> bugList;
    void Start()
    {
        gameMap = new GameMapper();
        bugList = new List<Bug>();

        int numberOfLadies = Random.Range(3, 10);
        for (int i = 0; i < numberOfLadies; i++)
        {
            LadyBug bug = Instantiate(lady, gameMap.GetSpawnPosition(), Quaternion.identity);
            bug.SetMap(gameMap);
            bugList.Add(bug);
        }
        int numberOfBees = Random.Range(3, 10);
        for (int i = 0; i < numberOfBees; i++)
        {
            Bee bug = Instantiate(bee, gameMap.GetSpawnPosition(), Quaternion.identity);
            bug.SetMap(gameMap);
            bugList.Add(bug);
        }
        int goldLadyBugs = Random.Range(3, 10);
        for (int i = 0; i < goldLadyBugs; i++)
        {
            GoldLadyBug bug = Instantiate(goldLadyBug, gameMap.GetSpawnPosition(), Quaternion.identity);
            bug.SetMap(gameMap);
            bugList.Add(bug);
        }
    }
}
