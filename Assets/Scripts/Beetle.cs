using UnityEngine;

public class Beetle : Bug
{
    public GameObject deathAnimation;

    public override float baseSpeed
    {
        get { return 2f; }
    }
    public override void PlayDeathAnimation() {
        Debug.Log("The Beetle Died!!");
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
    }
}
