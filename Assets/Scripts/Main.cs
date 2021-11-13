using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public LadyBug lady;
    public GameMapper gameMap;
    public List<LadyBug> ladies;
    void Start()
    {
        gameMap = new GameMapper();
        ladies = new List<LadyBug>();
        int numberOfLadies = Random.Range(3, 10);
        for (int i = 0; i < numberOfLadies; i++)
        {
            LadyBug b = Instantiate(lady, gameMap.GetSpawnPosition(), Quaternion.identity);
            b.SetMap(gameMap);
            ladies.Add(b);
        }
    }
    void Update()
    {

    }
}
