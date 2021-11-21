using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEvents : MonoBehaviour
{
    public delegate void TimerEventHandler(int x);

    public static event TimerEventHandler onUpdate;

    public static void TimerUpdate(int x)
    {
        if (onUpdate != null)
        {            
            onUpdate(x);
        }
    }
}
