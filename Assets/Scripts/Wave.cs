using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
public class Wave
{
    public List<(Bug, int)> bugRegistry;
    List<Bug> bugList;
    int waveCount;
    public Wave(List<(Bug, int)> bugRegistry, int waveCount)
    {
        BugEvents.onDeath += this.bugDead;
        bugList = new List<Bug>();
        this.bugRegistry = bugRegistry;
        this.waveCount = waveCount;
    }
    public async void StartWave()
    {
        foreach ((Bug, int) item in bugRegistry)
        {
            bugList.AddRange(await generateBugs(item.Item1, item.Item2));
        }
    }
    public async Task<List<Bug>> generateBugs(Bug bug, int count)
    {
        var spawnRate = Random.Range(0, 3);
        var delay = 0;
        if (bugList.Count > 3 && bugList.Count < 10)
        {
            delay = 1000;
        }
        if (waveCount > 10)
        {
            delay = 1500;
        }
        await Task.Delay(spawnRate * delay);
        return BugGenerator.generate(bug: bug, count: count);
    }
    public void bugDead(Bug bug)
    {
        bugList.Remove(bug);
        if (bugList.Count <= 2 && waveCount > 2)
        {
            WaveEvents.WaveComplete(this);
            BugEvents.onDeath -= this.bugDead;
        }
        else if (bugList.Count == 0)
        {
            WaveEvents.WaveComplete(this);
            BugEvents.onDeath -= this.bugDead;
        }
    }
}
