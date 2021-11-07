using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{

    public Text scoreLabel;
    public StaminaBar staminaBar;
    private int score = 0;
    private int touchStaminaCost = 12;
    
    private bool isExhausted = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (isExhausted)
            {
                return;
            }

            staminaBar.UseStamina(touchStaminaCost);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, 100.0f);

            if (hit.transform != null && hit.transform.gameObject != null)
            {
                switch (hit.transform.gameObject.tag)
                {
                    case "Bee":
                        score -= 2;
                        break;
                    case "Ant":
                        score += 1;
                        break;
                    case "Beetle":
                        score += 5;
                        break;
                    default:
                        break;
                }
                

                GameObject.Destroy(hit.transform.gameObject);
                
                scoreLabel.text = "Score: " + score;
            }
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
}
