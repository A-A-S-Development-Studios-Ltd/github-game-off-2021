using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEvents : MonoBehaviour
{
    public delegate void WaveEventHandler(LevelWave wave);

    public static event WaveEventHandler onComplete;

    public static void WaveComplete(LevelWave wave)
    {
        if (onComplete != null)
        {
            onComplete(wave);
        }
    }
}
