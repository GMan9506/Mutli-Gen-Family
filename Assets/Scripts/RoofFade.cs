using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoofFade : MonoBehaviour
{

    public SpriteRenderer roof1;
    public SpriteRenderer roof2;
    public SpriteRenderer roof3;
    public bool fade;
    public float fadeSpeed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") {
        
            if(fade && roof1.color.a == 1)
                StartCoroutine(fadeOut());
            else if(roof1.color.a == 0)
                StartCoroutine(fadeIn());

        }
    }

    private void FadeScene() {
        // Face the scene to black, begin first animation clip with grandma, car pulling up, and camera.
        roof1.color = Color.Lerp(roof1.color, Color.white, fadeSpeed * Time.deltaTime);
        roof2.color = Color.Lerp(roof2.color, Color.white, fadeSpeed * Time.deltaTime);
        roof3.color = Color.Lerp(roof3.color, Color.white, fadeSpeed * Time.deltaTime);

    }

    public IEnumerator fadeIn()
    {
        do
        {
            // Start fading towards black.
            FadeScene();

            // If the screen is almost black...
            if (roof1.color.a >= 0.99f)
            {
                roof1.color = Color.white;
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    private void FadeScene1() {
        // Face the scene to black, begin first animation clip with grandma, car pulling up, and camera.
        roof1.color = Color.Lerp(roof1.color, Color.clear, fadeSpeed * Time.deltaTime);
        roof2.color = Color.Lerp(roof2.color, Color.clear, fadeSpeed * Time.deltaTime);
        roof3.color = Color.Lerp(roof3.color, Color.clear, fadeSpeed * Time.deltaTime);

    }

    public IEnumerator fadeOut()
    {
        do
        {
            // Start fading towards black.
            FadeScene1();

            // If the screen is almost black...
            if (roof1.color.a <= 0.001f)
            {
                roof1.color = Color.clear;
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }



}
