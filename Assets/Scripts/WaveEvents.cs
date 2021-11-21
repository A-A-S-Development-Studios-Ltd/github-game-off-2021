using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEvents : MonoBehaviour
{
    public delegate void WaveEventHandler(Wave wave);

    public static event WaveEventHandler onComplete;

    public static void WaveComplete(Wave wave)
    {
        if (onComplete != null)
        {
            onComplete(wave);
        }
    }
}
