using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookLineHit : MonoBehaviour
{

    public bool hit;

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Knife") {
            if(Input.GetKeyDown("space")) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(138/255f, 212/255f, 228/255f);
                hit = true;
                // Check if last line before removing itself
                foreach(CookLineHit line in CookMini2.lines) {
                    if(!line.hit) {
                        return;
                    }
                }
                // This is unreachable, unless we've run out of lines.
                if(CookMini2.ready)
                CookMini2.spawnFoodAndCheck();
            }
            else {
                //play bad sound effect
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Knife") {
            if(Input.GetKeyDown("space")) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(138/255f, 212/255f, 228/255f);
                hit = true;
                // Check if last line before removing itself
                foreach(CookLineHit line in CookMini2.lines) {
                    if(!line.hit) {
                        return;
                    }
                }
                // This is unreachable, unless we've run out of lines.
                CookMini2.spawnFoodAndCheck();
            }
            else {
                //play bad sound effect
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Knife") {
            if(Input.GetKeyDown("space")) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(138/255f, 212/255f, 228/255f);
                gameObject.GetComponent<Collider2D>().enabled = false;
                hit = true;
                // Check if last line before removing itself
                foreach(CookLineHit line in CookMini2.lines) {
                    if(!line.hit) {
                        return;
                    }
                }
                // This is unreachable, unless we've run out of lines.
                CookMini2.spawnFoodAndCheck();
            }
            else {
                //play bad sound effect
            }
        }
    }


}
