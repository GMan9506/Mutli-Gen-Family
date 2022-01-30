using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    enum GameState {CUTSCENE, MOVEMENT, MINIGAME }
    GameState state;

    // Start is called before the first frame update
    public string CurrentMinigame;
    public Move Player;

    void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        Player = GameObject.FindObjectOfType<Move>();
    }

    // Update is called once per frame
   
    public void ChangeState(int pNewState)
    {
        state = (GameState)pNewState;
        switch (state)
        {
            case GameState.CUTSCENE:
                Player.canMove = false;
                break;
            case GameState.MOVEMENT:
                Player.canMove = true;
                break;
            case GameState.MINIGAME:
                Player.canMove = false;
                break;
        }
    }
    public void MinigameStart(string MinigameName)
    {
        CurrentMinigame = MinigameName;
        ChangeState((int)GameState.MINIGAME);
    }

    public void MinigameCompleted()
    {
        SceneManager.UnloadSceneAsync(CurrentMinigame);
        ChangeState((int)GameState.CUTSCENE);
    }
}
