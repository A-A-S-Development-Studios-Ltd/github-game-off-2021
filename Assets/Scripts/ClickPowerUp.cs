using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPowerUp : MonoBehaviour
{   
    Vector2 targetPosition;
    string tagType;

    // Start is called before the first frame update
    void Start()
    {
        tagType = gameObject.tag;
        Debug.Log("Tag Type:" + tagType);

        switch(tagType){
            case "PowerHoney":
                targetPosition = GameObject.FindGameObjectsWithTag("PC-Honey")[0].transform.position;                       
                break;
            case "PowerMagnify":
                targetPosition = GameObject.FindGameObjectsWithTag("PC-Magnify")[0].transform.position;                       
                break;
            case "PowerSprayCan":
                targetPosition = GameObject.FindGameObjectsWithTag("PC-SprayCan")[0].transform.position;                       
                break;
            case "PowerTimer":
                targetPosition = GameObject.FindGameObjectsWithTag("PC-Timer")[0].transform.position;                       
                break;
        }
       
    }

    void FixedUpdate() {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, 4 * Time.deltaTime);
    }   

    private void OnMouseDown()
    {
        Debug.Log("Clicked PowerUp");
        Destroy(gameObject);
    }    
}
