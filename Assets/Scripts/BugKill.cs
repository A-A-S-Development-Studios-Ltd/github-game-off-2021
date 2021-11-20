using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugKill : MonoBehaviour
{
    public Animator ani;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ani.SetBool("isDead", true);
        }
    }
}
