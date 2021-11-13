using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    private float timeRemaining = 60;
    private bool timerIsRunning = false;
    private Text label;

    void Start()
    {
        timerIsRunning = true;
        label = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;

            DisplayTime(timeRemaining);
        }
        else
        {
            timerIsRunning = false;
            timeRemaining = 0;
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        label.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // MARK: - Public exposure

    public void SetTimeRemaining(float value)
    {
        timeRemaining = value;
    }

    public void ToggleTimer()
    {
        timerIsRunning = !timerIsRunning;
    }
}
