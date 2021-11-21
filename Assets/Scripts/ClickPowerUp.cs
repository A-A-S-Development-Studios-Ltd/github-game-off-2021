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
        targetPosition = GameObject.FindGameObjectsWithTag((string)powerUpSlots[gameObject.tag])[0].transform.position;
    }

    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, 6 * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
