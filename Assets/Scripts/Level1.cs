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
        WaveEvents.onComplete += this.OnWaveComplete;
        StartNextWave();
    }
    void StartNextWave()
    {
        currentWave = GetRamdomWave();
        currentWave.StartWave();
    }
    void OnWaveComplete(LevelWave wave)
    {
        StartNextWave();
    }
    LevelWave GetRamdomWave()
    {
        Debug.Log("generating random wave");
        Dictionary<Bug, int> bugs = new Dictionary<Bug, int>();
        bugs.Add(ant, 2);
        bugs.Add(bee, 2);
        // bugs.Add(beetle, 2);
        // bugs.Add(goldLadyBug, 2);
        // bugs.Add(fireAnt, 2);
        // bugs.Add(ladyBug, 2);
        // bugs.Add(stinkBug, 2);
        return new LevelWave(bugs, 2);
    }
}
