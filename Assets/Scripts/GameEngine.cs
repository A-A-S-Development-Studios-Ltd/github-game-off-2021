using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum GameState
{
    PLAY,
    PAUSE,
    WIN,
    LOOSE,
    FINISHED
}

public class GameEngine : MonoBehaviour
{

    public Text scoreLabel;
    public Text popupScoreLabel;
    public Image badge1;
    public Image badge2;
    public Image badge3;
    public Image badge4;
    public Image badge5;
    public StaminaBar staminaBar;
    public PopupManager popup;
    public Text waveLabel;
    private int score = 0;
    private int missStaminaCost = 10;

    private bool isExhausted = false;

    public TimerController timer;
    private GameState gameState = GameState.PLAY;

    private AudioSource audioSource;

    private void Start()
    {
        timer.InitWithValue(3);
        BugEvents.onDeath += this.updateScore;

        audioSource = GetComponent<AudioSource>();
        PlayGameAudio();
    }
    void OnApplicationQuit()
    {
        gameState = GameState.FINISHED;
    }
    private void FixedUpdate()
    {
        switch (gameState)
        {
            case GameState.PLAY:
                PlayLoop();
                break;
            case GameState.LOOSE:
                PlayGameOverAudio();
                timer.ToggleTimer();
                gameState = GameState.FINISHED;
                PrepareEndModal();
                break;
            case GameState.WIN:
                // TODO: - Display win overlay
                break;
            case GameState.PAUSE:
                // TODO: - Display pause overlay
                timer.ToggleTimer();
                break;
            case GameState.FINISHED:
                break;
        }
    }


    private void PrepareEndModal()
    {
        if (score >= 150)
        {
            badge1.sprite = Resources.Load<Sprite>("Sprites/star-gold");
        }

        if (score >= 500)
        {
            badge2.sprite = Resources.Load<Sprite>("Sprites/star-gold");
        }

        if (score >= 1000)
        {
            badge3.sprite = Resources.Load<Sprite>("Sprites/star-gold");
        }

        if (score >= 5000)
        {
            badge4.sprite = Resources.Load<Sprite>("Sprites/star-gold");
        }

        if (score >= 9000)
        {
            badge5.sprite = Resources.Load<Sprite>("Sprites/star-gold");
        }

        popup.ShowModal();
    }

    private void PlayGameAudio()
    {
        audioSource.volume = 0.5f;
        audioSource.loop = true;
        AudioClip audioClip = (AudioClip)Resources.Load("Audio/dominoespizzaakacatchme");
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void PlayGameOverAudio()
    {
        audioSource.volume = 0.1f;
        audioSource.loop = false;
        AudioClip audioClip = (AudioClip)Resources.Load("Audio/game_over");
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isExhausted)
            {
                staminaBar.UseStamina(0);
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100.0f);
            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            staminaBar.UseStamina(missStaminaCost);
        }
    }

    public void updateScore(Bug bug)
    {
        if (scoreLabel != null && popupScoreLabel != null)
        {

            score += bug.score;
            scoreLabel.text = "Score: " + score;
            popupScoreLabel.text = "" + score;
        }
    }

    public void updateWave(int waveCount)
    {
        if (waveLabel != null)
        {
            waveLabel.text = "Wave: " + waveCount;
        }
    }

    public void updateTime(int newtime)
    {
        timer.IncreaseTime(newtime);
    }


    private void PlayLoop()
    {
        if (timer.GetRemainingTime() <= 0f)
        {
            gameState = GameState.LOOSE;
            return;
        }
    }

    public bool IsExhausted()
    {
        return isExhausted;
    }

    public void SetExaustion(bool value)
    {
        isExhausted = value;
    }

    public bool IsPlaying()
    {
        return gameState == GameState.PLAY;
    }
    public bool IsFinished()
    {
        return gameState == GameState.FINISHED;
    }

    public void TriggerPause()
    {
        if (gameState == GameState.PLAY || gameState == GameState.PAUSE)
        {
            gameState = Time.timeScale == 1 ? GameState.PAUSE : GameState.PLAY;
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }
    }
}
