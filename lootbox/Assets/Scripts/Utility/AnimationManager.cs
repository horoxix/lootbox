using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    // Fades alpha in or out for an image.
    public IEnumerator FadeTo(float aValue, float aTime, Image image)
    {
        float alpha = image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(alpha, aValue, t));
            image.color = newColor;
            yield return null;
        }
    }

    public void SetBool(Animator animator,string boolean, bool value)
    {
        animator.SetBool(boolean, value);
    }

    public IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        }
        while (animation.isPlaying);
    }
}