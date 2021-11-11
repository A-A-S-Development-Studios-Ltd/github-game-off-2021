using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AntBehaviour : MonoBehaviour
{

    private Animator animator;

    private bool isWalking = false;
    private bool isIdle = false;
    private int idleChances = 0;
    private int walkingPace = 4;

    private float zValue;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", isWalking);

        zValue = Camera.main.WorldToViewportPoint(transform.position).z;
    }

    private void FixedUpdate()
    {
        if (!isWalking && !isIdle)
        {
            var random = Random.value;

            if (random * 100 <= idleChances)
            {
                isIdle = true;

                animator.SetBool("isWalking", isWalking);

                Vector2 position = Camera.main.ViewportToWorldPoint(new Vector3(transform.position.x, transform.position.y, 100f));

                transform.DOMove(position, 2).OnComplete(() => {
                    isIdle = false;
                    isWalking = false;
                    idleChances = 0;
                });
            } else
            {
                isWalking = true;

                animator.SetBool("isWalking", isWalking);

                var xRandom = Random.value;
                var yRandom = Random.value;
                Vector3 destination = Camera.main.ViewportToWorldPoint(new Vector3(xRandom, yRandom, zValue));

                Vector3 direction = destination - transform.position;
                transform.up= direction;

                transform.DOMove(destination, walkingPace)
                    .SetEase(Ease.OutCubic)
                    .OnComplete(() => {
                        isIdle = false;
                        isWalking = false;
                        idleChances += 1;
                    }
                );
            }
        }
    }
}
