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
        StartNextWave();
    }
    Wave GetRamdomWave()
    {
        Dictionary<Bug, int> bugs = new Dictionary<Bug, int>();
        bugs.Add(ant, Random.Range(1, waveCount));
        bugs.Add(bee, Random.Range(1, waveCount));
        bugs.Add(beetle, Random.Range(1, waveCount));
        bugs.Add(goldLadyBug, 2);
        bugs.Add(fireAnt, Random.Range(1, 3));
        bugs.Add(ladyBug, Random.Range(1, waveCount));
        bugs.Add(stinkBug, Random.Range(1, waveCount));
        return new Wave(bugs, waveCount);
    }
}
