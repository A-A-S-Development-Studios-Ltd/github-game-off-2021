using UnityEngine;
using UnityEngine.UI;

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
        timer.InitWithValue(6);
        BugEvents.onDeath += this.updateScore;

        audioSource = GetComponent<AudioSource>();
        PlayGameAudio();
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
        if (score >= 20)
        {
            badge1.sprite = Resources.Load<Sprite>("Sprites/badge-mosquito");
        }

        if (score >= 100)
        {
            badge2.sprite = Resources.Load<Sprite>("Sprites/badge-lady-bug");
        }

        if (score >= 250)
        {
            badge3.sprite = Resources.Load<Sprite>("Sprites/badge-butterfly");
        }

        if (score >= 1000)
        {
            badge4.sprite = Resources.Load<Sprite>("Sprites/badge-dragonfly");
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

            staminaBar.UseStamina(missStaminaCost);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100.0f);
            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            
        }
    }

    public void updateScore(Bug bug)
    {
        if (scoreLabel != null)
        {   
            Debug.Log("Updating Score...");
            score += bug.score;
            scoreLabel.text = "Score: " + score;
            popupScoreLabel.text = "" + score;
        } else {
            Debug.Log("Missing Score Label");
        }
    }
 
    public void updateWave(int waveCount)
    {
        if (waveLabel != null)
        {   
            Debug.Log("Updating Wave...");
            waveLabel.text = "Wave: " + waveCount;
        } else {
            Debug.Log("Missing Wave Label");
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


    public void TriggerPause()
    {
        if (gameState == GameState.PLAY || gameState == GameState.PAUSE)
        {
            gameState = Time.timeScale == 1 ? GameState.PAUSE : GameState.PLAY;
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }
    }
}
