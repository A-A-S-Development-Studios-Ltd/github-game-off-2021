using System.Collections;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;

    private bool _readyToSpawn = true;

    void Start()
    {
        startPos = transform.position;

        StartCoroutine(SpawnCloud());
    }

    private void FixedUpdate()
    {
        if (_readyToSpawn)
        {
            StartCoroutine(SpawnCloud());
        }
    }


    IEnumerator SpawnCloud()
    {
        _readyToSpawn = false;

        float randomInterval = Random.Range(spawnInterval - 2f, spawnInterval + 2f);
        float elapsedTime = 0f;

        while (elapsedTime < randomInterval) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)]);

        startPos.y = Random.Range(startPos.y - 10f, startPos.y + 10f);
        float scale = Random.Range(0.8f, 1.2f);

        cloud.transform.localScale = new Vector2(scale, scale);

        cloud.transform.position = startPos;
        cloud.GetComponent<CloudController>().InitWithValues(Random.Range(1.5f, 3.5f), endPoint.transform.position.x);

        _readyToSpawn = true;
    }
}
