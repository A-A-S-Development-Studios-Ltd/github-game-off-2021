using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public Ant ant;
    public Bee bee;
    public Beetle beetle;
    public GoldLadyBug goldLadyBug;
    public FireAnt fireAnt;
    public LadyBug ladyBug;
    public StinkBug stinkBug;
    public List<Bug> bugList;
    public LevelWave currentWave;
    void Start()
    {
        currentWave = GetRamdomWave();
        currentWave.StartWave();
    }
    private void Update()
    {
        if (currentWave != null)
        {
            if (currentWave.IsDone())
            {

                spawnNextWave();

            }
        }
    }
    void spawnNextWave()
    {
        Debug.Log("Shoudl spawn next wave!");
    }
    LevelWave GetRamdomWave()
    {
        Dictionary<Bug, int> bugs = new Dictionary<Bug, int>();
        bugs.Add(ant, 2);
        bugs.Add(bee, 2);
        bugs.Add(beetle, 2);
        bugs.Add(goldLadyBug, 2);
        bugs.Add(fireAnt, 2);
        bugs.Add(ladyBug, 2);
        bugs.Add(stinkBug, 2);
        return new LevelWave(bugs, 2);
    }
}
