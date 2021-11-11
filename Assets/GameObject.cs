using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject : MonoBehaviour
{
    public LadyBug lady;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lady, new Vector2(0, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
