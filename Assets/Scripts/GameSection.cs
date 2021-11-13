using UnityEngine;
public class GameSection
{
    private float _minX;
    private float _minY;
    private float _maxX;
    private float _maxY;

    public GameSection(float minX, float minY, float maxX, float maxY)
    {
        _minX = minX;
        _minY = minY;
        _maxX = maxX;
        _maxY = maxY;

    }
    public Vector3 GetRandomPosition()
    {
        float pointX = Random.Range(_minX, _maxX);
        float pointY = Random.Range(_minY, _maxY);
        return Camera.main.ScreenToWorldPoint(new Vector3(pointX, pointY, 1));
    }
}
