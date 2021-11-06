using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{

    public Text scoreLabel;
    private int score = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse clicked");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, 100.0f);

            Debug.Log("hit: " + hit);
            Debug.Log("collider: " + hit.collider);

            if (hit.transform.gameObject != null)
            {
                GameObject.Destroy(hit.transform.gameObject);
                score += 1;
                scoreLabel.text = "Score: " + score;
            }
        }
    }
}
