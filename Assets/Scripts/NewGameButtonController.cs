using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButtonController : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
    }
}
