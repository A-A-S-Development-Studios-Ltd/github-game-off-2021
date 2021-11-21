using System.Collections;
using System.Collections.Generic;
public class LevelWave
{
    public LadyBug lady;
    public Dictionary<Bug, int> bugRegistry;
    List<Bug> bugList;
    bool isDone = false;
    int spawnRate;
    // Start is called before the first frame update
    public LevelWave(Dictionary<Bug, int> bugRegistry, int spawnRate)
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
    private void Update()
    {

    }
    public bool IsDone()
    {
        return isDone;
    }
    public void bugDead(Bug bug)
    {
        bugList.Remove(bug);
        if (bugList.Count == 0)
        {
            isDone = true;
        }
    }
}
