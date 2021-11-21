using UnityEngine;

public class FireAnt : Bug
{
    public GameObject deathAnimation;
    public GameObject powerUp;

    public override float baseSpeed
    {
        get { return 2f; }
    }
    public override int score
    {
        get { return 25; }
    }

    public override void PlayDeathAnimation()
    {
        Debug.Log("The Fire Ant Died!!");
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
        Instantiate(powerUp, this.transform.position, Quaternion.identity);
    }
}
