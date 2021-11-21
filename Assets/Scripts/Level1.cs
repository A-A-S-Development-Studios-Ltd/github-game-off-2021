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

    public List<Bug> bugList;
    public LevelWave currentWave;


    LevelWave w2;

    void Start()
    {

        //BugGenerator.generate(count: 10, bug: lady);

        Dictionary<Bug, int> level1Bugs = new Dictionary<Bug, int>();
        level1Bugs.Add(lady, 10);
        level1Bugs.Add(goldLadyBug, 2);
        level1Bugs.Add(fireAnt, 1);
        LevelWave w1 = new LevelWave(level1Bugs, 2);
        currentWave = w1;
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
}
