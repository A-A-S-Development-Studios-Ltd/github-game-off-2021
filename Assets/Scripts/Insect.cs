using UnityEngine;

public class Insect: MonoBehaviour
{
    private InsectState state;

}

public enum InsectState
{
    NONE,
    IDLE,
    MOVING
}