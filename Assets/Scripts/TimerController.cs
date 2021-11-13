using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    private float startingTimer = 60;
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

        if (timeToDisplay <= 6)
        {
            label.color = Color.red;
        }
        else if (timeToDisplay > startingTimer * 60 / 100)
        {
            label.color = Color.blue;
        }
        else if (timeToDisplay > startingTimer * 40 / 100)
        {
            label.color = Color.green;
        }
        else
        {
            label.color = Color.yellow;
        }

        label.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // MARK: - Public exposure

    public void initWithValue(float value)
    {
        startingTimer = value;
        timeRemaining = value;
    }

    public void SetTimeRemaining(float value)
    {
        timeRemaining = value;
    }

    public void ToggleTimer()
    {
        timerIsRunning = !timerIsRunning;
    }
}
