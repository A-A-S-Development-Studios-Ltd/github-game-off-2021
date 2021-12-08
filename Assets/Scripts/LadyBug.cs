using UnityEngine;

public class LadyBug : Bug
{
    public GameObject deathAnimation;
    public GameObject fireDeathAnimation;
    public GameObject gasDeathAnimation;

    public override float baseSpeed
    {
        get { return 2f; }
    }
    public override int score
    {
        get { return 5; }
    }
    public override void PlayDeathAnimation()
    {
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
    }
    public override void PlayFireDeathAnimation()
    {
        Instantiate(fireDeathAnimation, this.transform.position, Quaternion.identity);
    }
    public override void PlayGasDeathAnimation()
    {
        Instantiate(gasDeathAnimation, this.transform.position, Quaternion.identity);
    }
}
