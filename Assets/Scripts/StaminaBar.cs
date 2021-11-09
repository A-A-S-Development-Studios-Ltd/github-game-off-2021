using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private int maxStamina = 100;
    private int currentStamina;
    private bool isShaking = false;
    public float shakeDuration = 1f;

    public static StaminaBar instance;
    public GameEngine gameEngine;
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
        if (gameEngine.IsExhausted())
        {
            Debug.Log("You're exhausted");

            if (!isShaking) { StartCoroutine(ShakeCamera()); }

            return;
        }

        currentStamina += amount;

        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
            gameEngine.SetExaustion(true);
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
                gameEngine.SetExaustion(false);
            }
        }
    }

    IEnumerator ShakeCamera()
    {

        isShaking = true;
        Transform cameraTransform = Camera.main.transform;
        Vector3 startPosition = cameraTransform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            cameraTransform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }

        cameraTransform.position = startPosition;
        isShaking = false;
    }

}