using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Image reloadBarImage; // Reference to the UI Image representing the reload bar
    public float reloadTime; // Duration of the reload time in seconds

    private void Start()
    {
        // Start the reload process
        StartCoroutine(Reloadv2());
        reloadTime = PlayerPrefs.GetFloat("ReloadSpeedValue");
    }

    public void Update()
    {
        if (Firing.isFired == true)
        {
            reloadBarImage.fillAmount = 0f;
            StartCoroutine(Reloadv2());
        }
    }

    public IEnumerator Reloadv2()
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < reloadTime)
        {
            // Calculate the fill amount
            float fillAmount = elapsedTime / reloadTime;
            reloadBarImage.fillAmount = fillAmount;

            // Increment the elapsed time
            elapsedTime += Time.fixedDeltaTime;

            // Wait until the next frame
            yield return null;
        }

        // Ensure the fill amount is set to 1 (100%)
        reloadBarImage.fillAmount = 1f;
        Firing.isFired = false;
    }
}
