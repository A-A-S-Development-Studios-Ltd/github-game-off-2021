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
    public bool autoDestroy;
    int deathStep = 0;

    public virtual float baseSpeed
    {
        get { return 2f; }
    }
    public virtual int score
    {
        get { return 5; }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
        autoDestroy = false;
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
            if (autoDestroy)
            {
                deathStep++;
                targetPosition = gameMap.GetSpawnPosition();
            }
            moveSpeed = baseSpeed * speedMultiplier;
            isMoving = true;
        }
    }
    public virtual void PlayDeathAnimation()
    {
        //code is in subclass
    }
    private void OnMouseDown()
    {
        this.PlayDeathAnimation();
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        BugEvents.BugDead(this);
    }
    private void FixedUpdate()
    {
        if (isMoving && Vector2.Distance(rb.position, targetPosition) > 0.3f)
        {
            Vector3 moveDirection = (Vector3)targetPosition - rb.transform.position;
            if (moveDirection != Vector3.zero)
            {
                float angle = (Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - 90f;
                rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            float step = moveSpeed * Time.deltaTime;
            animator.speed = step * 100;
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, step);
        }
        else
        {
            isMoving = false;
            if (autoDestroy && deathStep > 1)
            {
                Destroy(this.gameObject);
            }

            return;
        }
        rb.MovePosition(rb.position + currentPosition * moveSpeed * Time.fixedDeltaTime);
    }
}