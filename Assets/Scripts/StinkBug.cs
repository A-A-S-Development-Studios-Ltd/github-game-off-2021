using UnityEngine;

public class StinkBug : Bug
{
    public GameObject deathAnimation;
    public GameObject powerUp;
    
    public override float baseSpeed
    {
        get { return 3f; }
    }
    
    public override void PlayDeathAnimation() {
        Debug.Log("The StinkBug Died!!");
        Instantiate(deathAnimation, this.transform.position, Quaternion.identity);
        Instantiate(powerUp, this.transform.position, Quaternion.identity);
    }    
}
