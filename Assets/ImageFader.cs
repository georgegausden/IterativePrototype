using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public PlaySoundWhenNearSun soundScript;
    public float fadeSpeed = 0.1f;
    public float maxAlpha = 255f;

    private Image image;
    private bool fadingIn = true;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (soundScript.nearSun)
        {
            float alpha = Mathf.Lerp(0f, maxAlpha, fadeSpeed * Time.deltaTime);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            if (fadingIn && alpha >= maxAlpha)
            {
                fadingIn = false;
            }
            else if (!fadingIn && alpha <= 0f)
            {
                fadingIn = true;
            }
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            fadingIn = true;
        }
    }
}
