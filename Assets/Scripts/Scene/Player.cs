using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveForce = 0;
    public float jumpForce = 0;
    public int jumpFrames = 0;

    [HideInInspector]
    public Item hand = null;

    [HideInInspector]
    public float direction = 1;

    private int groundCount = 0;
    private int lastGroundedFrame = 0;
    
    void FixedUpdate() {
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();

        if(this.groundCount > 0) {
            this.lastGroundedFrame = Time.frameCount;
        }

        Debug.Log(Time.frameCount - this.lastGroundedFrame);
        if(Input.GetKey(KeyCode.W) && (this.groundCount > 0 || Time.frameCount - this.lastGroundedFrame < this.jumpFrames)) {
            body.AddForce(new Vector2(0, this.jumpForce));
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            float dir = 0;

            if(Input.GetKey(KeyCode.A)) {
                dir--;
            }

            if(Input.GetKey(KeyCode.D)) {
                dir++;
            }

            if(dir != 0) {
                body.AddForce(new Vector2(this.moveForce * dir, 0));

                this.direction = dir;
                this.GetComponent<SpriteRenderer>().flipX = this.direction < 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && this.hand != null && this.hand.Use(this)) {
            this.hand = null;
        }
    }

    void OnTriggerEnter2D(Collider2D c) {
        if(!c.isTrigger) {
            this.groundCount++;
        }
    }

    void OnTriggerExit2D(Collider2D c) {
        if(!c.isTrigger) {
            this.groundCount--;
        }
    }
}
