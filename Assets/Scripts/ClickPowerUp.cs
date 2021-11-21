using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPowerUp : MonoBehaviour
{
    Vector2 targetPosition;
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
        targetPosition = GameMapper.Instance.GetSpawnPosition();
        //targetPosition = GameObject.FindGameObjectsWithTag((string)powerUpSlots[gameObject.tag])[0].transform.position;        
    }

    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, 3 * Time.deltaTime);

        if(Vector2.Distance(gameObject.transform.position, targetPosition) < 0.3f) {
            Debug.Log("Destroyed PowerUp");
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked PowerUp");
        TimerEvents.TimerUpdate(10);
        Destroy(gameObject);
    }
}
