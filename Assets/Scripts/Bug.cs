using UnityEngine;
using DG.Tweening;

public class Bug: MonoBehaviour
{
    private BugState state = BugState.NONE;
    private Animator animator;
    private int timeSinceRest = 0;

    public virtual int walkingPace
    {
        get { return 4; }
    }

    private float zValue;

    private void Start()
    {
        animator = GetComponent<Animator>();
        zValue = Camera.main.WorldToViewportPoint(transform.position).z;
    }

    private void FixedUpdate()
    {
        if (state == BugState.NONE)
        {

            if (Random.value * 100 <= timeSinceRest)
            {
                Rest();
            } else
            {
                Move();
            }
        }
    }

    private void Rest()
    {
        state = BugState.IDLE;
        animator.SetBool("isMoving", false);

        Vector2 position = Camera.main.ViewportToWorldPoint(new Vector3(transform.position.x, transform.position.y, zValue));

        transform
            .DOMove(position, walkingPace)
            .OnComplete(() => {
                state = BugState.NONE;
                timeSinceRest = 0;
            });
    }

    private void Move()
    {
        state = BugState.MOVING;
        animator.SetBool("isMoving", true);

        var xRandom = Random.value;
        var yRandom = Random.value;
        Vector3 destination = Camera.main.ViewportToWorldPoint(new Vector3(xRandom, yRandom, zValue));
        Vector3 direction = destination - transform.position;
        transform.up = direction;

        transform
            .DOMove(destination, walkingPace)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => {
                state = BugState.NONE;
                timeSinceRest += 1;
            });
    }
}

public enum BugState
{
    NONE,
    IDLE,
    MOVING
}