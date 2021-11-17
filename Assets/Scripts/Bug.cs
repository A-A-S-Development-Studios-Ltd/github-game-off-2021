using UnityEngine;
public class Bug : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb;
    private GameMapper gameMap;
    bool isMoving;
    public float moveSpeed = 5f;
    Vector2 targetPosition;
    Vector2 currentPosition;
    public virtual float baseSpeed
    {
        get { return 2f; }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
    }
    public void SetMap(GameMapper map)
    {
        this.gameMap = map;
    }

    void Update()
    {
        if (!isMoving && this.gameMap != null)
        {
            var speedMultiplier = Random.Range(2, 6);
            if (speedMultiplier == 3)
            {
                targetPosition = gameMap.GetSpawnPosition();
            }
            else
            {
                targetPosition = gameMap.GetRandomPosition();
            }
            moveSpeed = baseSpeed * speedMultiplier;
            isMoving = true;
        }
    }
    private void FixedUpdate()
    {
        if (this.GetType().ToString() != "LadyBug")
        {
            Debug.Log("Target x: " + targetPosition.x + ", y: " + targetPosition.y);
            Debug.Log("RB x: " + rb.position.x + ", y: " + rb.position.y);
        }
        //if (isMoving &&  rb.position != targetPosition)
        if (isMoving && Vector2.Distance(rb.position, targetPosition) > 0.3f)
        {

            Vector3 moveDirection = (Vector3)targetPosition - rb.transform.position;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            if (this.GetType().ToString() == "LadyBug")
            {
                if ((Time.frameCount * moveSpeed) % 8 == 0)
                {
                    Vector3 lTemp = transform.localScale;
                    lTemp.y = transform.localScale.y * -1;
                    transform.localScale = lTemp;
                }
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
        // squishAnimation.SetTrigger("Active");
        // animator.SetBool("isMoving", false);
        Destroy(this.gameObject);
    }
}