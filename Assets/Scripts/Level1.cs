using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;


public class Level1 : MonoBehaviour
{
    private Ant ant;
    private Bee bee;
    private Beetle beetle;
    private GoldLadyBug goldLadyBug;
    private FireAnt fireAnt;
    private LadyBug ladyBug;
    private StinkBug stinkBug;

    public List<Bug> bugList;
    public List<Bug> levelBugList;
    public int waveCount;
    public int killCount;
    public int bugCount;
    public int bugLimit;
    public Text waveLabel;
    private GameEngine gameEngine;

    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }




    void Start()
    {

        ladyBug = Resources.Load<LadyBug>("Prefabs/LadyBug 1");
        bee = Resources.Load<Bee>("Prefabs/Bee 1");
        ant = Resources.Load<Ant>("Prefabs/Ant");
        beetle = Resources.Load<Beetle>("Prefabs/Beetle 1");
        fireAnt = Resources.Load<FireAnt>("Prefabs/FireAnt");
        goldLadyBug = Resources.Load<GoldLadyBug>("Prefabs/GoldBug 1");
        stinkBug = Resources.Load<StinkBug>("Prefabs/StinkBug");
        BugEvents.onDeath += this.bugDead;
        bugList = new List<Bug> { ant, bee, beetle, goldLadyBug, fireAnt, ladyBug, stinkBug, ant, bee, beetle, fireAnt, ladyBug, stinkBug, ladyBug, ant, beetle, ladyBug, ant, beetle };
        gameEngine = GameObject.FindWithTag("GameEngine").GetComponent<GameEngine>();
        waveCount = 0;
        killCount = 0;
        bugCount = 0;
        bugLimit = 20;
        BugEvents.onDeath += OnSquish;
        GenerateWave();
    }
    public void OnSquish(Bug bug)
    {
        killCount++;
    }
    private void Update()
    {
        bugCount = levelBugList.Count;
    }
    void GenerateWave()
    {
        if (gameEngine.IsFinished())
        {
            return;
        }
        waveCount++;
        gameEngine.updateWave(waveCount);

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

            if (max <= 1)
            {
                max = 2;
            }
            bugs.Add((bee, Random.Range(1, max)));
        }
        if (waveCount > 6)
        {
            bugs.Add((goldLadyBug, 2));
            bugs.Add((beetle, Random.Range(3, max + 6)));
        }
        if (waveCount > 8)
        {
            if (max <= 3)
            {
                max = 4;
            }
            bugs.Add((fireAnt, Random.Range(3, max)));
        }
        if (waveCount > 10)
        {
            bugs.Add((stinkBug, Random.Range(3, max)));
        }
        foreach ((Bug, int) item in bugs)
        {
            levelBugList.AddRange(BugGenerator.generate(bug: item.Item1, count: item.Item2));
        }

        var bugs2 = new List<(Bug, int)>();
        if (waveCount > 10)
        {
            int maxCount = (waveCount > 20) ? waveCount : 20;
            for (var i = 10; i < maxCount; i++)
            {
                Bug bug = bugList[Random.Range(0, bugCount)];
                int count = Random.Range(1, 2);
                bugs2.Add((bug, count));
            }
        }
        StartCoroutine(spawnBugs(bugs2));
    }
    IEnumerator spawnBugs(List<(Bug, int)> bugs)
    {
        while (levelBugList.Count > bugLimit)
        {
            yield return new WaitForSeconds(1f);
        }
        foreach ((Bug, int) item in bugs)
        {
            yield return new WaitForSeconds(2f);
            levelBugList.AddRange(BugGenerator.generate(bug: item.Item1, count: item.Item2));
        }
    }
    public void bugDead(Bug bug)
    {
        levelBugList.Remove(bug);

        if (levelBugList.Count <= 2 && waveCount > 2)
        {
            GenerateWave();
        }
        else if (levelBugList.Count == 0)
        {
            GenerateWave();
        }
    }

}
