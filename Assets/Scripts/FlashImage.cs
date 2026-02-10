using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image image = null;
    Coroutine currentRoutine = null;

    private void Awake()
    {
        image = GetComponent<Image>();

    }

    public void StartFlash(float secondsForOneFlash, float maxAlpha, Color newColor)
    {
        image.color = newColor;

        //ensure maxAlpha isn't above 1
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAlpha));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAlpha)
    {
        //animate flash in
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
        {
            //create a new color change and apply it
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            image.color = colorThisFrame;

            //wait until the next frame
            yield return null;
        }

        //animate flash out
        float flasOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
        {

            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flasOutDuration);
            image.color = colorThisFrame;

            //wait until the next frame
            yield return null;
        }

        image.color = new Color32(0, 0, 0, 0);
    }

}
