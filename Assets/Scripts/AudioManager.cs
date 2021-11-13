using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance = null;
    private AudioSource levelAudio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        levelAudio = GetComponent<AudioSource>();
        levelAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
