using UnityEngine;

public class Beetle : Bug
{
    public GameObject deathAnimation;

    public override float baseSpeed
    {
        get { return 2f; }
    }
    public override int score
    {
        get { return 15; }
    }
    public override void PlayDeathAnimation()
    {
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
    }
}
