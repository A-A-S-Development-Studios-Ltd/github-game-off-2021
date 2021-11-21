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
    public StaminaBar staminaBar;
    private int score = 0;
    private int missStaminaCost = 12;
    private int hitStaminaCost = 2;

    private bool isExhausted = false;

    AudioSource audioSource;

    public TimerController timer;
    private GameState gameState = GameState.PLAY;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer.InitWithValue(60);
    }

    private void FixedUpdate()
    {
        switch (gameState)
        {
            case GameState.PLAY:
                PlayLoop();
                break;
            case GameState.LOOSE:
                timer.ToggleTimer();
                gameState = GameState.FINISHED;
                break;
            case GameState.WIN:
                // TODO: - Display win overlay
                break;
            case GameState.PAUSE:
                // TODO: - Display pause overlay
                break;
            case GameState.FINISHED:
                break;
        }
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isExhausted)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, 100.0f);

            // Debug.Log("test: " + hit);
            if (hit.transform != null && hit.transform.gameObject != null)
            {

            }

            Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            Debug.Log(hitInformation);
            Debug.Log(hitInformation.collider);

            if (hitInformation.collider != null)
            {      
                staminaBar.UseStamina(hitStaminaCost);
                GameObject touchedObject = hitInformation.transform.gameObject;
                Debug.Log("Touched " + touchedObject.transform.name);

                switch (touchedObject.transform.tag)
                {
                    case "Bee":
                        score += 25;                        
                        break;
                    case "Ant":
                        score += 5;
                        break;
                    case "Beetle":
                        score += 15;
                        break;
                    case "FireAnt":
                        score += 25;
                        break;
                    case "GoldBug":
                        score += 100;
                        break;
                    case "LadyBug":
                        score += 25;
                        break;
                    case "StinkBug":
                        score += 25;
                        break;
                    default:
                        break;
                }

                scoreLabel.text = "Score: " + score;     
                              
            } else {
                staminaBar.UseStamina(missStaminaCost);
            }
        }
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

    public void TriggerPause()
    {
        gameState = Time.timeScale == 1 ? GameState.PAUSE : GameState.PLAY;
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }
}
