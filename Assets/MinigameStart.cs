using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameStart : MonoBehaviour
{
    public TMP_Text minigameText;

    // Applies an upwards force to all rigidbodies that enter the trigger.
    void OnTriggerStay(Collider other)
    {
        minigameText.text = "Press E to start minigame.";
    }
}
