using UnityEngine;

public class Ant : Bug
{
    public GameObject deathAnimation;
    public GameObject fireDeathAnimation;
    public GameObject gasDeathAnimation;
    public GameObject pointIncrease;

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
        Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
    }    
    public override void PlayFireDeathAnimation()
    {
        Instantiate(fireDeathAnimation, this.transform.position, Quaternion.identity);
        Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
    } 
    public override void PlayGasDeathAnimation()
    {
        Instantiate(gasDeathAnimation, this.transform.position, Quaternion.identity);
        Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
    }
}
