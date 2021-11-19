using UnityEngine;

public class CreditPopup : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public void ShowModal()
    {
        transition.SetTrigger("showModal");
    }

    public void HideModal()
    {
        transition.SetTrigger("hideModal");
    }
}
