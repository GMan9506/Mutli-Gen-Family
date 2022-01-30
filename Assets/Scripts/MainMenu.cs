using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Image FadeImg;
    public float fadeSpeed;
    public Animator startAnimator;
    public bool started;
    public GameObject mainMenuObj;
    public Camera mainCamera;
    public GameObject HUD;

    // MainMenu GameObject being disabled will disable this main menu

    void Update()
    {
        if(Input.anyKey && !started) {
            StartCoroutine(NextScene());
            started = true;
        }
    }

    private void FadeScene() {
        // Face the scene to black, begin first animation clip with grandma, car pulling up, and camera.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
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
                Debug.Log("hey");
                loadNextScene();
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
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    public IEnumerator fadeOut()
    {
        do
        {
            // Start fading towards black.
            FadeScene1();

            // If the screen is almost black...
            if (FadeImg.color.a <= 0.001f)
            {
                FadeImg.gameObject.SetActive(false);
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    private void loadNextScene() {
        mainMenuObj.SetActive(false);
        StartCoroutine(fadeOut());
        // Animation begins playing.
        startAnimator.Play("anim1");
        StartCoroutine(nextStep());
    }

    private IEnumerator nextStep() {
        yield return new WaitForSeconds(25);
        startAnimator.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        HUD.SetActive(true);
        GameManager1.completed("intro");
    }

}
