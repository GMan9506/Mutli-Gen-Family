using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MinigameStart : MonoBehaviour
{
    public TMP_Text minigameText;
    public string minigameSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") {
        Debug.Log("Player entered minigame trigger.");
        minigameText.text = "Press                 to enter minigame";
        minigameText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player") {
        Debug.Log("Player left minigame trigger.");
        minigameText.text = "";
        minigameText.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
        if (Input.GetKey("space")) {
        minigameText.gameObject.SetActive(false);
        SceneManager.LoadScene(minigameSceneName, LoadSceneMode.Additive);
        Debug.Log("Player entered " + minigameSceneName + " minigame.");
        }
    }
    }
}
