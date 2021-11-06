using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BeeBehaviour : MonoBehaviour
{

    public bool idle = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (idle)
        {
            idle = false;

            var xRandom = Random.value;
            var yRandom = Random.value;
            Vector2 destination = Camera.main.ViewportToWorldPoint(new Vector3(xRandom, yRandom, 100f));
            
            transform.DOMove(destination, 1).SetEase(Ease.InOutFlash).OnComplete(() => {
                idle = true;
            });
        }
    }
}
