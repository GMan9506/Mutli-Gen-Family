using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMinigame : MonoBehaviour
{

    public SpriteRenderer indicator;
    public bool direction;
    public float fadeSpeed;

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

        if(Input.GetKey("space")) {
            if(indicator.transform.localScale.x > 3 && indicator.transform.localScale.x < 5) {
                Debug.Log("Successfully took pic!");
            }
            else {
                Debug.Log("Failed to take pic.");
            }
        }
    }
}
