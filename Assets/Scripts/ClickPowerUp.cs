using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPowerUp : MonoBehaviour
{
    Vector2 targetPosition;
    string tagType;

    public GameEngine gameEngine;

    Hashtable powerUpSlots = new Hashtable() {
        {"PowerHoney", "PC-Honey"},
        {"PowerMagnify", "PC-Magnify"},
        {"PowerSprayCan", "PC-SprayCan"},
        {"PowerTimer", "PC-Timer"},
    };

    // Start is called before the first frame update
    void Start()
    {
        randomizeValues();
        
        //targetPosition = GameObject.FindGameObjectsWithTag((string)powerUpSlots[gameObject.tag])[0].transform.position;
        
    }

    private void randomizeValues()
    {
        int randX = Random.Range(1000, 10000);
        int randY = Random.Range(1000, 10000);
        int posX = Random.Range(0, 10);
        int posY = Random.Range(0, 10);

        if(posX >= 5) {
            randX = 0 - randX;
        }

        if(posY >= 5) {
            randY = 0 - randY;
        }

        targetPosition = new Vector2(randX, randY);
    }

    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, 3 * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked PowerUp");
        gameEngine.updateTime(10);
        Destroy(gameObject);
    }
}
