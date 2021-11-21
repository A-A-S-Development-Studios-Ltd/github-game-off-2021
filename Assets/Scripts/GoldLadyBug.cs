using UnityEngine;

public class GoldLadyBug : Bug
{
    public GameObject deathAnimation;
    public GameObject powerUp;

    public override float baseSpeed
    {
        get { return 3f; }
    }
    public override int score
    {
        get { return 100; }
    }

    public override void PlayDeathAnimation()
    {

        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
        Instantiate(powerUp, this.transform.position, Quaternion.identity);
    }
    private void OnDestroy()
    {
        BugEvents.BugDead(this);
    }
}
