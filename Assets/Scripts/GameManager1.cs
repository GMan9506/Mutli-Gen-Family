using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    public SpriteRenderer player;
    public Sprite[] sprites;
    // youngest to oldest, 0 daut, 1 son, 2 mom, 3 dad, 4 granmy
    public static GameManager1 instance;
    public GameObject[] minigames;

    public GameObject dad;
    public GameObject mom;
    public GameObject daut;
    public GameObject son;
    public GameObject grandma;

    public GameObject everything;

    public void Start() {
        instance = this;
    }
/*

1. Intro cutscene text 2. Free walk as Tina (Daughter) 3. Enter ingredient selection minigame
a. Complete first ingredient list, trigger text b. Complete second ingredient, trigger text
C. End minigame, trigger text 4. Enter free roam (Dad) 5. Enable Setting Table Minigame
a. Intro text, start game b. First setting done, enable text c. Second setting done, enable text
d. End minigame, trigger text cutscene 6. Enter free roam (Grandmom) 7. Enable cooking minigame
a. Intro text, start game b. First done, enable text C. Second done, enable text
d. End minigame, trigger text cutscene 8. Enter free roam (Daughter) 9. Enable arrange minigame
a. Intro text, start game b. First done, text C. Second done, text
d. End minigame, cutscene text 10. Enter free roam (Son) 11. Start photo minigame
a. Finish minigame, endgame text screen with photo 12. Credits

*/

public static void completed(string task) {
    instance.completedTask(task);
}


public void completedTask(string task) {

    switch(task) {

        case "intro":
            dad.SetActive(true);
            mom.SetActive(true);
            son.SetActive(true);
            grandma.SetActive(true);
            player.color = Color.white;
            break;

        case "minigame0":    
            everything.SetActive(true);
            player.gameObject.GetComponent<Move>().canMove = true;
                        player.color = Color.white;

            player.sprite = sprites[3];
            
            //player.transform.position = dad.position;
            dad.SetActive(false);
            daut.SetActive(true);
            player.transform.position = dad.transform.position;
            // hide idle dad sprite
            // 
            minigames[0].SetActive(false);
            minigames[1].SetActive(true);
            break;


        case "minigame1":    
        
            everything.SetActive(true);
            player.gameObject.GetComponent<Move>().canMove = true;
                        player.color = Color.white;

            player.sprite = sprites[4];
            // reappear dad
            //player.transform.position = dad.position;
            Debug.Log("hey");
            grandma.SetActive(false);
            dad.SetActive(true);
            player.transform.position = grandma.transform.position;            // hide idle grandma sprite
            // 
            minigames[1].SetActive(false);
            minigames[2].SetActive(true);
            break;

        case "minigame2":    
        
            everything.SetActive(true);
            player.gameObject.GetComponent<Move>().canMove = true;
                        player.color = Color.white;

            player.sprite = sprites[0];
            // reappear grandma
            //player.transform.position = dad.position;
            daut.SetActive(false);
            grandma.SetActive(true);
            player.transform.position = daut.transform.position;            // hide idle grandma sprite
            // 
            minigames[2].SetActive(false);
            minigames[3].SetActive(true);
            break;

        case "minigame3":    
        
            everything.SetActive(true);
            player.gameObject.GetComponent<Move>().canMove = true;
                        player.color = Color.white;

            player.sprite = sprites[1];
            // reappear daughter
            //player.transform.position = dad.position;
            son.SetActive(false);
            daut.SetActive(true);
            player.transform.position = son.transform.position;            // hide idle grandma sprite
            // 
            minigames[3].SetActive(false);
            minigames[4].SetActive(true);
            break;

    }

}



}
