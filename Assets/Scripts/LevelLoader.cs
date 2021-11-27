using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public void LoadHomeScreen()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadSurvival()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
    }
}
