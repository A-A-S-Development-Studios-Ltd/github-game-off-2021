using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEvents : MonoBehaviour
{
    public delegate void BugEventHandler(Bug bug);

    public static event BugEventHandler onDeath;

    public static void BugDead(Bug bug)
    {
        if (onDeath != null)
        {
            onDeath(bug);
        }
    }
}
