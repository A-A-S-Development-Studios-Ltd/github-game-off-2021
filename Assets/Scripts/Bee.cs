using UnityEngine;

public class Bee : Bug
{
    public GameObject deathAnimation;
    public GameObject powerUp;

    public override float baseSpeed
    {
        get { return 3f; }
    }
    public override int score
    {
        get { return 25; }
    }

    public override void PlayDeathAnimation()
    {
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
        Instantiate(powerUp, this.transform.position, Quaternion.identity);
    }

}