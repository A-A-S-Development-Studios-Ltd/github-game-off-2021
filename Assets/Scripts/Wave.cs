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
    GameEngine gameEngine;
    private int maxBugsOnScreen;
    private int groupCount;
    public Wave(List<(Bug, int)> bugRegistry, int waveCount, GameEngine gameEngine)
    {
        this.gameEngine = gameEngine;
        BugEvents.onDeath += this.bugDead;
        bugList = new List<Bug>();
        this.bugRegistry = bugRegistry;
        this.waveCount = waveCount;
        this.maxBugsOnScreen = 24;
        this.groupCount = 0;
    }
    public void StartWave()
    {
        foreach ((Bug, int) item in bugRegistry)
        {
            // TODO: - Delay is buggy on web builds.
            //bugList.AddRange(await generateBugs(item.Item1, item.Item2));
            bugList.AddRange(BugGenerator.generate(bug: item.Item1, count: item.Item2));
            groupCount++;
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
        while (!gameEngine.IsPlaying() || maxBugsOnScreen < bugList.Count)
        {
            await Task.Delay(1000);
        }
        return BugGenerator.generate(bug: bug, count: count);
    }
    public void bugDead(Bug bug)
    {
        bugList.Remove(bug);

        if (bugList.Count <= 2 && waveCount > 2 && groupCount == bugRegistry.Count)
        {
            WaveEvents.WaveComplete(this);
            BugEvents.onDeath -= this.bugDead;
        }
        else if (bugList.Count == 0 && groupCount == bugRegistry.Count)
        {
            WaveEvents.WaveComplete(this);
            BugEvents.onDeath -= this.bugDead;
        }
    }
}
