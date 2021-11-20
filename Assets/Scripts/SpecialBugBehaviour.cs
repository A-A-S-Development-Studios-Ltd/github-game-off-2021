using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBugBehaviour : MonoBehaviour
{
    float targetTime;
    float timeInterval = 5f;
    float startTime;
    bool autoDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        targetTime = Time.time + timeInterval;
        autoDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoDestroy && Time.time > targetTime)
        {
            gameObject.GetComponent<GoldLadyBug>().autoDestroy = true;
            autoDestroy = true;
        }
    }
}
