using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyBug : MonoBehaviour
{
    public float moveSpeed = 5f;
    float baseSpeed = 2f;
    public Rigidbody2D rb;
    public Animator squishAnimation;
    bool isMoving;
    bool hasMoved;
    int crossingState;

    private GameMapper _gameMap;

   
    Vector2 targetPosition;
    Vector2 currentPosition;


    // Start is called before the first frame update
    void Start()
    {
        //hasMoved = false;
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
        crossingState = 0;
        
        //squishAnimation = this.GetComponent<Animator>();
    }

    public void SetMap(GameMapper map)
    {
        _gameMap = map;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isMoving)
        {
            var speedMultiplier = Random.Range(2, 6);
            Debug.Log(speedMultiplier);
            if (speedMultiplier == 3)
            {
                targetPosition = _gameMap.GetSpawnPosition();
            }
            else
            {
                targetPosition = _gameMap.GetRandomPosition();
              
            }
             
            


            moveSpeed = baseSpeed * speedMultiplier;
            //targetPosition = _gameMap.GetRandomPosition();
            isMoving = true;
        }
    }
    private void FixedUpdate()
    {
        if (isMoving && rb.position != targetPosition)
        {
            Vector3 moveDirection = (Vector3)targetPosition - rb.transform.position;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            

            //moving
            float step = moveSpeed * Time.deltaTime;
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, step);
        }
        else
        {
            isMoving = false;
        }
        rb.MovePosition(rb.position + currentPosition * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnMouseDown()
    {
        Debug.Log("t was clicked");
       // squishAnimation.SetTrigger("Active");
        Destroy(this.gameObject);
    }
}
