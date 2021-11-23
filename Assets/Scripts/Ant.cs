using UnityEngine;

public class Ant : Bug
{
    public GameObject deathAnimation;

    public override float baseSpeed
    {
        get { return 1f; }
    }
    public override int score
    {
        get { return 10; }
    }
    public override void PlayDeathAnimation()
    {
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
    }
}
