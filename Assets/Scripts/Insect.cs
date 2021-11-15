using UnityEngine;

public class Insect: MonoBehaviour
{
    private InsectState state = InsectState.NONE;
    private Animator animator;
    private int timeSinceRest = 0;

    private float _waitTime;
    private float _startWaitTime = 3f;

    private Vector2 _destination;
    private float minX = -55f;
    private float maxX = 55f;
    private float minY = 15f;
    private float maxY = 70f;

    public virtual int walkingPace
    {
        get { return 4; }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        _waitTime = _startWaitTime;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case InsectState.NONE:
                if (Random.value * 100 <= timeSinceRest)
                {
                    state = InsectState.IDLE;
                }
                else
                {
                    _destination = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    state = InsectState.MOVING;
                }
                break;
            case InsectState.MOVING:
                Move();
                break;
            case InsectState.IDLE:
                Rest();
                break;
        }
    }

    private void Rest()
    {
        if (_waitTime < 0)
        {
            _waitTime = _startWaitTime;
            state = InsectState.NONE;
        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }

    private void Move()
    {
        animator.SetBool("isMoving", true);

        transform.position = Vector2.MoveTowards(transform.position, _destination, walkingPace * Time.deltaTime);

        if (Vector2.Distance(transform.position, _destination) < 0.2f)
        {
            state = InsectState.IDLE;
            animator.SetBool("isMoving", false);
        }
    }
}

public enum InsectState
{
    NONE,
    IDLE,
    MOVING
}