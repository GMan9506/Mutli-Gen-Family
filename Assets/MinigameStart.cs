using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameStart : MonoBehaviour
{
    public TMP_Text minigameText;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered minigame trigger.");
        minigameText.text = "Press E to start minigame.";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player left minigame trigger.");
        minigameText.text = "";
    }
}
