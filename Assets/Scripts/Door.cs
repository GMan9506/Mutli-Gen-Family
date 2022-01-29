using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Door : MonoBehaviour
{
    public TMP_Text interactText;
    public Animator doorAnim;
    public bool currentlyOpen;

    public void Start() {
        doorAnim.SetBool("open", currentlyOpen);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") {
        Debug.Log("Player entered door trigger.");
        interactText.text = "Press                 to " + (currentlyOpen ? "close" : "open") + " door";
        interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player") {
        Debug.Log("Player left door trigger.");
        interactText.text = "";
        interactText.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
        
        if (Input.GetKey("space")) {
        interactText.gameObject.SetActive(false);
        currentlyOpen = !currentlyOpen;
        doorAnim.SetBool("open", currentlyOpen);
        Debug.Log("Player opened/closed door.");
        }
    }
    }
}
