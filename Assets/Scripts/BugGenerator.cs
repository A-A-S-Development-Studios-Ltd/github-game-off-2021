using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugGenerator : MonoBehaviour
{
    public static List<Bug> generate(int count, Bug bug)
    {
        List<Bug> bugs = new List<Bug>();
        for (int i = 0; i < count; i++)
        {
            Bug bugInstance = Instantiate(bug, GameMapper.Instance.GetSpawnPosition(), Quaternion.identity);
            bugInstance.SetMap(GameMapper.Instance);
            bugs.Add(bugInstance);
        }
        return bugs;
    }
}

