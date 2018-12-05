using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {
    [SerializeField]
    private CanvasGroup settingsCanvasGroup;


    public void ToggleSettings(int value)
    {
        StartCoroutine(FadeTo(value, 1));
        settingsCanvasGroup.interactable = !settingsCanvasGroup.interactable;
        settingsCanvasGroup.blocksRaycasts = !settingsCanvasGroup.blocksRaycasts;
    }

    // Fades alpha in or out for an image.
    public IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = settingsCanvasGroup.alpha;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            settingsCanvasGroup.alpha = Mathf.Lerp(alpha, aValue, t);
            yield return null;
        }
    }
}
