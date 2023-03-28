using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public PlaySoundWhenNearSun soundScript;
    public float fadeSpeed = 0.1f;
    public float maxAlpha = 1f;

    private Image image;
    private bool fadingIn = true;
    private float phase = 0f;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    private Image GetImage()
    {
        return image;
    }

    private void Update()
    {
        if (soundScript.nearSun)
        
        {
            float alpha = (255*Mathf.Sin(phase)+255);
            Debug.Log(alpha);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            if (fadingIn && alpha >= maxAlpha)
            {
                fadingIn = false;
                phase = 0f;
            }
            else if (!fadingIn && alpha <= 0f)
            {
                fadingIn = true;
                phase = 0f;
            }

            phase += Time.deltaTime * fadeSpeed;
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            phase = 0f;
        }
    }
}
