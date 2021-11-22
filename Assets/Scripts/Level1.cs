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
    public Wave currentWave;
    public int waveCount;
    void Start()
    {
        WaveEvents.onComplete += this.OnWaveComplete;
        waveCount = 0;
        StartNextWave();
    }
    void StartNextWave()
    {
        waveCount++;
        currentWave = GetRamdomWave();
        currentWave.StartWave();
        Debug.Log("Starting wave: " + waveCount);
    }
    void OnWaveComplete(Wave wave)
    {
        wave = null;
        currentWave = null;
        StartNextWave();
    }
    Wave GetRamdomWave()
    {
        var max = waveCount;
        if (max > 3)
        {
            max = waveCount % 3;
        }
        Dictionary<Bug, int> bugs = new Dictionary<Bug, int>();
        if (waveCount > 0)
        {
            bugs.Add(ladyBug, Random.Range(1, max));
        }
        if (waveCount > 2)
        {
            bugs.Add(bee, Random.Range(1, max));
        }
        if (waveCount > 4)
        {
            bugs.Add(goldLadyBug, 2);
            bugs.Add(beetle, Random.Range(1, max));
        }
        if (waveCount > 6)
        {
            bugs.Add(ant, Random.Range(1, max));
        }
        if (waveCount > 8)
        {
            bugs.Add(fireAnt, Random.Range(1, max));
        }
        if (waveCount > 10)
        {
            bugs.Add(stinkBug, Random.Range(1, max));
        }
        return new Wave(bugs, waveCount);
    }
}
