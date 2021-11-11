using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Spawner 
{
    static int spawnRange = 200;
    static int leftMin = 0 - spawnRange;
    static int leftMax = 0;
    static int topMin = Screen.height;
    static int topMax = Screen.height + spawnRange;
    static int rightMin = Screen.width;
    static int rightMax = Screen.width + spawnRange;
    static int bottomMin = 0 - spawnRange;
    static int bottomMax = 0;
    static int index = 1;

    enum SpawnDirection { LEFT,TOP,RIGHT,BOTTOM};


    public static Vector3 getSpawnPosition(){
        int direction = Random.Range(0, 3);

        Vector3 spawnPoint;

        switch (direction)
        {
            case (int)SpawnDirection.LEFT:
                spawnPoint = generateLeft();
                break;
            case (int)SpawnDirection.TOP:
                spawnPoint = generateTop();
                break;
            case (int)SpawnDirection.RIGHT:
                spawnPoint = generateRight();
                break;
            case (int)SpawnDirection.BOTTOM:
                spawnPoint = generateBottom();
                break;
            default:
                spawnPoint = generateLeft();
                break;
        }

        return Camera.main.ScreenToWorldPoint(spawnPoint);
    }
    private static Vector3 generateLeft()
    {
        float pointX = Random.Range(leftMin, leftMax);
        float pointY = Random.Range(bottomMin, topMax);
        return new Vector3(pointX, pointY, index);
    }

    private static Vector3 generateTop()
    {
        float pointX = Random.Range(leftMin, leftMax);
        float pointY = Random.Range(topMin, topMax);
        return new Vector3(pointX, pointY, index);

    }

    private static Vector3 generateRight()
    {
        float pointX = Random.Range(rightMin, rightMax);
        float pointY = Random.Range(bottomMin, topMax);
        return new Vector3(pointX, pointY, index);

    }

    private static Vector3 generateBottom()
    {
        float pointX = Random.Range(leftMin, rightMax);
        float pointY = Random.Range(bottomMin, bottomMax);
        return new Vector3(pointX, pointY, index);

    }
}
