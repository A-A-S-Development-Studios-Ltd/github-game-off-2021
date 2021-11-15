using UnityEngine;

public class CloudController : MonoBehaviour
{

    private float _speed = 2f;
    private float _endPosX;
    
    void Start()
    {
        
    }

    public void InitWithValues(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));

        if (transform.position.x > _endPosX)
        {
            Destroy(gameObject);
        }
    }
}
