using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public void TriggerPause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }
}
