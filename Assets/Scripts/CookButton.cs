using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CookButton : MonoBehaviour
{
    public int thisNum = 0;
    public int clickedsoFar = 0;
    public int timesClicked = 0;
    public Image FadeImg;
    public int fadeSpeed = 2;

    void OnMouseDown(){
        if(CookMini2.chosenBoilerNum == thisNum) {
            // good click sound
            clickedsoFar++;
            if(timesClicked == clickedsoFar) {
                // Fixed the heater.
                CookMini2.instance.boilers[thisNum].Stop();
                clickedsoFar = 0;
                StopAllCoroutines();
            } 
        } else {
            // error sound
        }
    }

    public void death() {
        StartCoroutine(deathSequence());
    }

    public IEnumerator deathSequence() {

        yield return new WaitForSeconds(Random.Range(5,15));
        var main = CookMini2.instance.boilers[thisNum].main;
        main.startSize = 7f;

        yield return new WaitForSeconds(Random.Range(15,30));
        // you've left the burner on.......
        main.startSize = 15f;
        // fade screen to black
        // prevent the player from hail-mary- game is over.
        foreach(CookButton but in CookMini2.instance.buttons) {
            but.gameObject.GetComponent<Collider2D>().enabled = false;
        }
        CookMini2.instance.gameEnded = true;

        yield return new WaitForSeconds(2);
        StartCoroutine(NextScene());

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
                if(CookMini2.instance.currentFood)
                Destroy(CookMini2.instance.currentFood);
                SceneManager.UnloadSceneAsync("Cooking");
                SceneManager.LoadScene("Cooking", LoadSceneMode.Additive);

                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }


}
