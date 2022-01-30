using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMinigame : MonoBehaviour
{

    public SpriteRenderer indicator;
    public bool direction;
    public float fadeSpeed;
    public Image FadeImg;
    public GameObject cameraGroup;
    public GameObject credits;
    public bool gameEnded;
    public GameObject cam;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(direction) {
        indicator.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            if(indicator.transform.localScale.x < 4) {
                indicator.color = Color.Lerp(indicator.color, Color.green, fadeSpeed * Time.deltaTime);
            }
            else {
                indicator.color = Color.Lerp(indicator.color, Color.red, fadeSpeed * Time.deltaTime);
            }
        }
        else {
        indicator.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            if(indicator.transform.localScale.x > 4) {
                indicator.color = Color.Lerp(indicator.color, Color.green, fadeSpeed * Time.deltaTime);
            }
            else {
                indicator.color = Color.Lerp(indicator.color, Color.red, fadeSpeed * Time.deltaTime);
            }
        }

        if(indicator.transform.localScale.x > 15f) {
            direction = false;
        }
        else if(indicator.transform.localScale.x < 1f) {
            direction = true;
        }

        if(Input.GetKeyDown("space")) {
            if(indicator.transform.localScale.x > 3 && indicator.transform.localScale.x < 5) {
                Debug.Log("Successfully took pic!");
                // flash screen white, appear photo on top, scroll down table for credits.
                if(!gameEnded) {
                StartCoroutine(NextScene());
                gameEnded = true;
                }
            }
            else {
                Debug.Log("Failed to take pic.");
            }
        }

    }


    private void FadeScene() {
        // Face the scene to black, begin first animation clip with grandma, car pulling up, and camera.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.white, fadeSpeed * Time.deltaTime);
    }

    public IEnumerator NextScene()
    {
        do
        {
            // Start fading towards black.
            FadeScene();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.99f)
            {
                FadeImg.color = Color.white;
                rollCredits();
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
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, 0.005f);
    }

    public IEnumerator NextScene1()
    {
        do
        {
            // Start fading towards black.
            FadeScene1();
            // If the screen is almost clear...
            if (FadeImg.color.a <= 0.001f)
            {
                FadeImg.color = Color.clear;
                Debug.Log("hey");
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    public void rollCredits() {
        GetComponent<SpriteRenderer>().enabled = false;
        cameraGroup.SetActive(false);
        credits.SetActive(true);
        StartCoroutine(NextScene1());

       // StartCoroutine(moveCameraDown());

    }

    private IEnumerator moveCameraDown() {
       // cam.transform.
       yield return null;
    }


}
