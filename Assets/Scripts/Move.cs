using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Top Down Movement, used for OUTSIDE of minigames. */

public class Move: MonoBehaviour {

    public bool canMove = true;
     public float speed = 15;
     private Vector2 velocity;
     private Rigidbody2D rb;
     private SpriteRenderer charact;

     private void Awake() {
          rb = GetComponent<Rigidbody2D>();
          velocity = Vector2.zero;
          charact = GetComponent<SpriteRenderer>();

     }
     private void Update() {
        if (!canMove)
            return;
          velocity.x = Input.GetAxisRaw("Horizontal");
          velocity.y = Input.GetAxisRaw("Vertical");
          if(velocity.x > 0) {
               charact.flipX = true;
          } else if(velocity.x < 0) {
               charact.flipX = false;
          }
     }
     private void FixedUpdate() {
           rb.MovePosition(rb.position + 
                (velocity.normalized * speed *
                 Time.fixedDeltaTime)); 
     }
}