using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GoodLuckManager : MonoBehaviour
{
    // The reference to the good luck image, assigned in Inspector
    public Image gLImage;

    // A reference to the currently executing coroutine
    private IEnumerator coroutine;

    // Update is called once per frame
    private void Update()
    {
        // Fade in - Wrong Attempt
        // Why? Because the entire for loop will take place during one frame,
        // which means that the image will immediately appear rather than
        // fade in over time.
        /*
        for (int i = 0; i < 256; i += 5)
        {
            gLImage.color = new Color(1, 1, 1, i / 255.0f);
        }
        */
    }

    // The method that the button OnClick event references
    public void WishUser()
    {
        // Stop the currently executing coroutine, so that we can restart the
        // fading in/out process without having the previous coroutine
        // modifying the color at the same time.
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        // Set reference to coroutine that will be executed & then start it
        coroutine = EntryExitCoroutine();
        StartCoroutine(coroutine);
    }

    // All coroutines have a return type of IEnumerator
    private IEnumerator EntryExitCoroutine()
    {
        // Fade in
        // Increase the image's alpha (transparency) value by 5 bits each frame
        for (int i = 0; i < 256; i += 5)
        {
            gLImage.color = new Color(1, 1, 1, i / 255.0f);

            // Stop execution until next frame
            yield return null;
        }

        // Stop execution until 2 seconds have passed
        yield return new WaitForSeconds(2);

        // Fade out
        // Decrease the image's alpha (transparency) value by 5 bits each frame
        for (int i = 255; i >= 0; i -= 5)
        {
            gLImage.color = new Color(1, 1, 1, i / 255.0f);

            // Stop execution until next frame
            yield return null;
        }
    }
}
