using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MinigameStart : MonoBehaviour
{
    public TMP_Text minigameText;
    public string minigameSceneName;
    public static int hey = 0;
    public GameObject everything;
    public Move player;

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
        if (Input.GetKeyDown("space")) {
        minigameText.gameObject.SetActive(false);
        GameManager1.completed("minigame" + hey);
        hey++;
        everything.SetActive(false);
        player.canMove = false;
        GameManager1.instance.player.color = Color.clear;
        SceneManager.LoadScene(minigameSceneName, LoadSceneMode.Additive);
        GameManager.instance.MinigameStart(minigameSceneName);
        Debug.Log("Player entered " + minigameSceneName + " minigame.");
        }
    }
    }
}
