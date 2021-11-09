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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", isWalking);
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
                Vector2 destination = Camera.main.ViewportToWorldPoint(new Vector3(xRandom, yRandom, 100f));

                transform.DOMove(destination, walkingPace).SetEase(Ease.InOutFlash).OnComplete(() => {
                    isIdle = false;
                    isWalking = false;
                    idleChances += 1;
                });
            }
        }
    }
}
