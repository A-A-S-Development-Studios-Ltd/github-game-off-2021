using UnityEngine;

public class Ant : Bug
{
    public GameObject deathAnimation;

    public override float baseSpeed
    {
        get { return 1f; }
    }
    public override void PlayDeathAnimation() {
        Debug.Log("The Ant Died!!");
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
    }
}
