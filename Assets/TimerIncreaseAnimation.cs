using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerIncreaseAnimation : MonoBehaviour
{
    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 5.0f);   
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, Time.deltaTime);
    }
}
