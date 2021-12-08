using UnityEngine;

public class FireAnt : Bug
{
    public GameObject deathAnimation;
    public GameObject specialDeathAnimation;
    public GameObject fireDeathAnimation;
    public GameObject gasDeathAnimation;
    public GameObject pointIncrease;
    public GameObject powerUp;

    private int dropRate = 25;

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
        int randomValue = Random.Range(0,100);

        if (randomValue <= dropRate) 
        {
            Instantiate(specialDeathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(powerUp, this.transform.position, Quaternion.identity);
            Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
        } 
        else  
        {
            Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
        }
    }
    
    public override void PlayFireDeathAnimation()
    {
        int randomValue = Random.Range(0,100);

        if (randomValue <= dropRate) 
        {
            Instantiate(specialDeathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(powerUp, this.transform.position, Quaternion.identity);
            Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
        } 
        else  
        {
            Instantiate(fireDeathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
        }
    }

    public override void PlayGasDeathAnimation()
    {
        int randomValue = Random.Range(0,100);

        if (randomValue <= dropRate) 
        {
            Instantiate(specialDeathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(powerUp, this.transform.position, Quaternion.identity);
            Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
        } 
        else  
        {
            Instantiate(gasDeathAnimation, this.transform.position, Quaternion.identity);
            Instantiate(pointIncrease, this.transform.position, Quaternion.identity);
        }
        
    }
}
