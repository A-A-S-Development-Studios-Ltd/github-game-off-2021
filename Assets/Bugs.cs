using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : MonoBehaviour
{
    public LadyBug lady;
    public List<LadyBug> ladies;

    // Start is called before the first frame update
    void Start()
    {
        int numberOfLadies = Random.Range(3, 20);


        for (int i = 0; i < numberOfLadies; i++)
        {
            ladies.Add(Instantiate(lady, Spawner.getSpawnPosition(), Quaternion.identity));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
