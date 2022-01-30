using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMini2 : MonoBehaviour
{

    public SpriteRenderer indicator;
    public bool direction;
    public float fadeSpeed;
    public GameObject[] foodList;
    public Transform foodSpawnLocation;
    public GameObject line;
    public static List<CookLineHit> lines;
    public int foodCount = 5;
    public int foodCountSoFar = 0;
    public static CookMini2 instance;
    public GameObject currentFood;
    public static bool ready;
    public bool gameEnded;
    public static int chosenBoilerNum;
    public ParticleSystem[] boilers;
    public CookButton[] buttons;

    void Start() {
        lines = new List<CookLineHit>();

        // Spawn the first fruit, lines on the fruit.
        spawnFood();

        instance = this;

        // Appears random, but..

        
        // FIXING HEAT MINI MINI GAME

        // Every 5-30 seconds, a boiler goes off.

        // Twice so at max, two boilers go off at same time.
        StartCoroutine(stove());
        StartCoroutine(stove());
    }

    private IEnumerator stove() {
        while(!gameEnded) {
            yield return new WaitForSeconds(Random.Range(0,30));
            // pick a random boiler and overheat it.
            chosenBoilerNum = Random.Range(0,boilers.Length);
            boilers[chosenBoilerNum].Play();
            buttons[chosenBoilerNum].timesClicked = Random.Range(1,15);
            buttons[chosenBoilerNum].death();
        }
    }

    // This method is called from CookLineHit()
    public static void spawnFoodAndCheck() {
        if(ready) {
            ready = false;
        // check food count before spawning another
        for(int x = lines.Count-1; x >= 0; x--) {
            Destroy(lines[x].gameObject);
            lines.RemoveAt(x);
        }
        Destroy(instance.currentFood);
        instance.foodCountSoFar++;
        if(instance.foodCountSoFar == instance.foodCount) {
            // End minigame. You've successfuly cut and managed the burners.
            GameManager.instance.MinigameCompleted();
        GameManager1.completed("minigame2");
        if(instance.currentFood)
        Destroy(instance.currentFood);
        instance.gameEnded = true;
            Debug.Log("You've won");
                    for(int x = lines.Count-1; x >= 0; x--) {
            Destroy(lines[x].gameObject);
            lines.RemoveAt(x);
        }
        }
        else {
            if(!instance.gameEnded)
            instance.spawnFood();
        }
        ready = true;
        }
    }

    // Food and lines
    void spawnFood() {
        currentFood = GameObject.Instantiate(foodList[Random.Range(0,foodList.Length)], foodSpawnLocation.position, Quaternion.identity);
        for(int x = 0; x < Random.Range(4,20); x++)
            lines.Add(GameObject.Instantiate(line,foodSpawnLocation.position + new Vector3(0f,Random.Range(currentFood.transform.position.y-currentFood.GetComponent<RectTransform>().rect.height/4,currentFood.transform.position.y+currentFood.GetComponent<RectTransform>().rect.height/4),0f),Quaternion.identity).GetComponent<CookLineHit>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // CHOPPING MINI-MINI GAME

        if(direction) {
        indicator.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
        }
        else {
        indicator.transform.position -= new Vector3(0.0f, 0.1f, 0.0f);
        }

        if(indicator.transform.position.y > 3.5f) {
            direction = false;
            CookMini2.ready = true;
        }
        else if(indicator.transform.position.y < -3.5f) {
            direction = true;
            CookMini2.ready = true;
        }

    }

}
