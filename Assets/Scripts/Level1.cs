using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{

    public LadyBug lady;
    public Bee bee;
    public Ant ant;
    public Beetle beetle;
    public GoldLadyBug goldLadyBug;
    public FireAnt fireAnt;
    public StinkBug stinkBug;
    public GameMapper gameMap;
    public List<Bug> bugList;
    void Start()
    {
        gameMap = new GameMapper();
        bugList = new List<Bug>();
        int count = Random.Range(1, 3);
        bugList.AddRange(bugGenerator(count: 10, bug: ant, gameMap: gameMap));
        // bugList.AddRange(bugGenerator(count: count, bug: lady, gameMap: gameMap));
        // //count = Random.Range(1, 5);
        // bugList.AddRange(bugGenerator(count: count, bug: bee, gameMap: gameMap));
        // //count = Random.Range(1, 2);
        // bugList.AddRange(bugGenerator(count: count, bug: goldLadyBug, gameMap: gameMap));
        // //count = Random.Range(1, 2);
        // bugList.AddRange(bugGenerator(count: count, bug: ant, gameMap: gameMap));
        // //count = Random.Range(1, 3);
        // bugList.AddRange(bugGenerator(count: count, bug: beetle, gameMap: gameMap));
        // //count = Random.Range(1, 3);
        // bugList.AddRange(bugGenerator(count: count, bug: stinkBug, gameMap: gameMap));
    }
    List<Bug> bugGenerator(int count, Bug bug, GameMapper gameMap)
    {
        List<Bug> bugs = new List<Bug>();
        for (int i = 0; i < count; i++)
        {
            Bug bugInstance = Instantiate(bug, gameMap.GetSpawnPosition(), Quaternion.identity);
            bugInstance.SetMap(gameMap);
            bugs.Add(bugInstance);
        }
        return bugs;
    }
}
