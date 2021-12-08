using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPowerUp : MonoBehaviour
{
    Vector2 targetPosition;
    private GameEngine gameEngine;   
    public GameObject fireAnimation;
    public GameObject gasAnimation;
    string tagType;

    Hashtable powerUpSlots = new Hashtable() {
        {"PowerHoney", "PC-Honey"},
        {"PowerMagnify", "PC-Magnify"},
        {"PowerSprayCan", "PC-SprayCan"},
        {"PowerTimer", "PC-Timer"},
    };

    // Start is called before the first frame update
    void Start()
    {
        gameEngine = GameObject.FindWithTag("GameEngine").GetComponent<GameEngine>();
        targetPosition = GameMapper.Instance.GetSpawnPosition();
    }

    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, 3 * Time.deltaTime);

        if (Vector2.Distance(gameObject.transform.position, targetPosition) < 0.3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        gameEngine.staminaBar.UseStamina(-8);

        if(this.gameObject.tag == "PowerTimer") 
        {
            TimerEvents.TimerUpdate(10);
        }

        if(this.gameObject.tag == "PowerMagnify") 
        {
            Instantiate(fireAnimation, this.transform.position, Quaternion.identity);
        }

        if(this.gameObject.tag == "PowerSprayCan") 
        {
            Instantiate(gasAnimation, this.transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
