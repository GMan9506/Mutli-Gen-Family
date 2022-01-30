using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TalkNPC : MonoBehaviour
{
    public TMP_Text interactText;
    public TMP_Text noticeMessage;
    public string name;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") {
        Debug.Log("Player entered talk trigger.");
        interactText.text = "Press                 to talk to " + name;
        interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player") {
        Debug.Log("Player left talk trigger.");
        interactText.text = "";
        noticeMessage.text = "";
        interactText.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
        Debug.Log("Still in grammys collider");
        if (Input.GetKey("space")) {
            interactText.gameObject.SetActive(false);
                // Integrate INK here----

                //Load the DialogManager Scene
                //Check to see if the DialogManager scene is already loaded.
                if ( !SceneManager.GetSceneByName("DialogManager").IsValid() )
                    SceneManager.LoadScene("DialogManager", LoadSceneMode.Additive);
                

                //noticeMessage.text = "She doesn't want to talk right now..";

                // Integerate INK here ---
                Debug.Log("Player is talking to person.");
        }
    }
    
}
}
