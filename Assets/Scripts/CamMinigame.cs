using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Vector3 targetPos;
    public float camSpeed;
    public Vector3 textTargetPos;
    public Vector3 textOriginalPos;
    public Vector3 camOriginalPos;
    public RectTransform textt;

    public void Start() {
        targetPos = cam.transform.position - new Vector3(0f,40f,0f);
        camOriginalPos = cam.transform.position;
        textTargetPos = textt.transform.position + new Vector3(0f,2500f,0f);
        textOriginalPos = textt.transform.position;
    }

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

       StartCoroutine(moveCameraDown());

        StartCoroutine(fade());

    }

    private IEnumerator moveCameraDown() {
        while(cam.transform.position.y >= targetPos.y) {

            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPos, camSpeed * Time.deltaTime);
            textt.transform.position = Vector3.Lerp(textt.transform.position, textTargetPos, camSpeed * Time.deltaTime);

            yield return null;

        }
       // cam.transform.
       yield break;
    }

    public IEnumerator fade() {
        yield return new WaitForSeconds(30);
        StartCoroutine(NextScene2());
    }


    private void FadeScene2() {
        // Face the scene to black, begin first animation clip with grandma, car pulling up, and camera.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, Time.deltaTime);
    }

    public IEnumerator NextScene2()
    {
        do
        {
            // Start fading towards black.
            FadeScene2();
            // If the screen is almost clear...
            if (FadeImg.color.a >= 0.99f)
            {
                FadeImg.color = Color.black;

                // Restart the game.
                SceneManager.LoadScene(0);


                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

}
