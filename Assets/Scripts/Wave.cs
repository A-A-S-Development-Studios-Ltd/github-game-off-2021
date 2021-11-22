using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
public class Wave
{
    public Dictionary<Bug, int> bugRegistry;
    List<Bug> bugList;
    int spawnRate;
    int waveCount;
    public Wave(Dictionary<Bug, int> bugRegistry, int waveCount)
    {
        BugEvents.onDeath += this.bugDead;
        bugList = new List<Bug>();
        this.bugRegistry = bugRegistry;
        this.spawnRate = 0;
        this.waveCount = waveCount;
    }
    public async void StartWave()
    {
        foreach (KeyValuePair<Bug, int> item in bugRegistry)
        {
            spawnRate = Random.Range(0, 3);
            bugList.AddRange(await generateBugs(item.Key, item.Value));
        }
    }
    public async Task<List<Bug>> generateBugs(Bug bug, int count)
    {
        if (bugList.Count > 3)
        {
            await Task.Delay(spawnRate * 1000);
        }
        return BugGenerator.generate(bug: bug, count: count);
    }
    public void bugDead(Bug bug)
    {
        bugList.Remove(bug);
        if (bugList.Count == 0)
        {
            WaveEvents.WaveComplete(this);
            BugEvents.onDeath -= this.bugDead;
        }
    }
}
