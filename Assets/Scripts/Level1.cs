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
    void Start()
    {
        bugList = new List<Bug> { ant, bee, beetle, goldLadyBug, fireAnt, ladyBug, stinkBug, ant, bee, beetle, fireAnt, ladyBug, stinkBug, ladyBug, ant, beetle, ladyBug, ant, beetle };

        WaveEvents.onComplete += this.OnWaveComplete;
        waveCount = 0;
        bugCount = 0;
        BugEvents.onDeath += OnSquish;
        //change infinite mode to change between modes
        isInfiniteMode = false;
        if (isInfiniteMode == false)
        {
            StartNextWave();
        }
    }
    private void Update()
    {
        if (isInfiniteMode == true)
        {
            Bug bug = bugList[Random.Range(0, bugList.Count - 1)];
            int count = Random.Range(1, 3);
            int time = Mathf.FloorToInt(Time.time);
            Debug.Log("playing infinite: " + time);
            if (bugCount < 3)
            {
                BugGenerator.generate(bug: bug, count: count);
                bugCount += count;
                bug = bugList[Random.Range(0, bugList.Count - 1)];
                BugGenerator.generate(bug: bug, count: count);
                bugCount += count;
            }
            else if (bugCount > 3 && bugCount < 11)
            {
                int ranMod = Random.Range(2, 3);
                if (time % ranMod == 0)
                {
                    BugGenerator.generate(bug: bug, count: count);
                    bugCount += count;
                }
            }
        }
    }
    public void OnSquish(Bug bug)
    {
        bugCount--;
    }

    void StartNextWave()
    {
        waveCount++;
        waveLabel.text = "Wave: " + waveCount;

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
        var max = waveCount;
        if(max <= 2) {
            max = 6;
        }
        if (max > 3)
        {
            max = waveCount % 3;
        }
        Dictionary<Bug, int> bugs = new Dictionary<Bug, int>();
        if (waveCount > 0)
        {
            bugs.Add(ladyBug, Random.Range(4, max+3));
        }
        if (waveCount > 3)
        {
            bugs.Add(ant, Random.Range(3, max+6));
            bugs.Add(bee, Random.Range(1, max));
        }
        if (waveCount > 6)
        {
            bugs.Add(goldLadyBug, 2);
            bugs.Add(beetle, Random.Range(3, max+6));
        }
        if (waveCount > 8)
        {
            bugs.Add(fireAnt, Random.Range(3, max));
        }
        if (waveCount > 10)
        {
            bugs.Add(stinkBug, Random.Range(3, max));
        }
        if (waveCount > 10)
        {
            Bug bug = bugList[Random.Range(0, bugList.Count - 1)];
            int count = Random.Range(3, 9);
            bugs[bug] = bugs[bug] + count;
        }
        if (waveCount > 14)
        {
            Bug bug = bugList[Random.Range(0, bugList.Count - 1)];
            int count = Random.Range(5, 12);
            bugs[bug] = bugs[bug] + count;
        }
        if (waveCount > 20)
        {
            Bug bug = bugList[Random.Range(0, bugList.Count - 1)];
            int count = Random.Range(6, 18);
            bugs[bug] = bugs[bug] + count;
        }
        //return gameObject.AddComponent<Wave>();
        return new Wave(bugs, waveCount);
    }
}
