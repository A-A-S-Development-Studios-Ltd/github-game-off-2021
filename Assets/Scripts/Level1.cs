using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Wave currentWave;
    public int waveCount;
    public int bugCount;
    public Text waveLabel;
    public bool isInfiniteMode;
    
    private GameEngine gameEngine;

    void Start()
    {
        bugList = new List<Bug> { ant, bee, beetle, goldLadyBug, fireAnt, ladyBug, stinkBug, ant, bee, beetle, fireAnt, ladyBug, stinkBug, ladyBug, ant, beetle, ladyBug, ant, beetle };
        gameEngine = GameObject.FindWithTag("GameEngine").GetComponent<GameEngine>();
        WaveEvents.onComplete += this.OnWaveComplete;
        waveCount = 0;
        bugCount = 0;
        BugEvents.onDeath += OnSquish;
        StartNextWave();
    }
    public void OnSquish(Bug bug)
    {
        bugCount--;
    }

    void StartNextWave()
    {
        waveCount++;
        gameEngine.updateWave(waveCount);

        currentWave = GetRamdomWave();
        currentWave.StartWave();
    }
    void OnWaveComplete(Wave wave)
    {
        wave = null;
        currentWave = null;
        StartNextWave();
    }
    Wave GetRamdomWave()
    {
        var bugs = new List<(Bug, int)>();
        var bugCount = bugList.Count - 1;
        var max = 0;
        if (max > 3)
        {
            max = waveCount % 3;
        }
        if (waveCount > 0)
        {
            bugs.Add((ladyBug, Random.Range(4, max + 3)));
        }
        if (waveCount > 3)
        {
            bugs.Add((ant, Random.Range(3, max + 6)));
            bugs.Add((bee, Random.Range(1, max)));
        }
        if (waveCount > 6)
        {
            bugs.Add((goldLadyBug, 2));
            bugs.Add((beetle, Random.Range(3, max + 6)));
        }
        if (waveCount > 8)
        {
            bugs.Add((fireAnt, Random.Range(3, max)));
        }
        if (waveCount > 10)
        {
            bugs.Add((stinkBug, Random.Range(3, max)));
        }
        if (waveCount > 10)
        {
            for (var i = 10; i < waveCount; i++)
            {
                Bug bug = bugList[Random.Range(0, bugCount)];
                int count = Random.Range(1, 3);
                bugs.Add((bug, count));
            }
        }
        return new Wave(bugs, waveCount);
    }
}
