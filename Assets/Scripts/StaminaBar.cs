using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private int maxStamina = 100;
    private int currentStamina;
    private bool isExhausted = false;

    public static StaminaBar instance;
    private Slider slider;

    private IEnumerator coroutine;

    private void Awake()
    {
        instance = this;
        slider = instance.GetComponent<Slider>();
    }

    void Start()
    {
        currentStamina = 0;
        slider.maxValue = maxStamina;
        slider.value = 0;

        coroutine = DecreaseStamina();
        StartCoroutine(coroutine);
    }

    public void UseStamina(int amount)
    {
        if (isExhausted)
        {
            Debug.Log("You're exhausted");
            return;
        }

        if (maxStamina - amount < currentStamina)
        {
            Debug.Log("Stamina is too high");
            return;
        }

        currentStamina += amount;

        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
            isExhausted = true;
        }
    }

    private void FixedUpdate()
    {
        slider.value = currentStamina;
    }

    IEnumerator DecreaseStamina()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentStamina = Mathf.Max(currentStamina - 10, 0);
            if (currentStamina == 0)
            {
                isExhausted = false;
            }
        }
    }

}