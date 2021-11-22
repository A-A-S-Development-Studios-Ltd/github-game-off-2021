using UnityEngine;

public class Bee : Bug
{
    public GameObject deathAnimation;
    public GameObject specialDeathAnimation;
    public GameObject powerUp;

    private int dropRate = 25;

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
        int randomValue = Random.Range(0,100);

        if (randomValue <= dropRate) 
        {
            Instantiate(specialDeathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(powerUp, this.transform.position, Quaternion.identity);
        } else  {
            Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
        }
    }

}