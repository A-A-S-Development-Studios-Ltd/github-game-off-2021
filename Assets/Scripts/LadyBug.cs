using UnityEngine;

public class LadyBug : Bug
{
    public override float baseSpeed
    {
        get { return 2f; }
    }
    private void OnDestroy()
    {
        Debug.Log("the LADY bug was destroyed");
    }
}
