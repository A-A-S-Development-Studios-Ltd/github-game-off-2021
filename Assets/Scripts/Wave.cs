using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wave
{
    public Dictionary<Bug, int> bugRegistry;
    List<Bug> bugList;
    int spawnRate;
    public Wave(Dictionary<Bug, int> bugRegistry, int spawnRate)
    {
        BugEvents.onDeath += this.bugDead;
        bugList = new List<Bug>();
        this.bugRegistry = bugRegistry;
        this.spawnRate = spawnRate;
    }
    public void StartWave()
    {

        foreach (KeyValuePair<Bug, int> item in bugRegistry)
        {
            bugList.AddRange(BugGenerator.generate(bug: item.Key, count: item.Value));
        }
    }
    public void bugDead(Bug bug)
    {
        bugList.Remove(bug);
        if (bugList.Count <= 2)
        {
            WaveEvents.WaveComplete(this);
            BugEvents.onDeath -= this.bugDead;
        }
    }
}
