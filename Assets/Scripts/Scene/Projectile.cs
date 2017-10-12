using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ItemMonoBehaviour {
    public Vector2 speed = Vector2.zero;
    public bool surviveHittingNonPlayers = false;

    public override bool Use(Player player) {
        GameObject proj = (GameObject) Instantiate(this.gameObject, new Vector2(player.transform.position.x + player.direction, player.transform.position.y), player.transform.rotation);

        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D projCollider = proj.GetComponent<Collider2D>();
        if(playerCollider != null && projCollider != null) {
            Physics2D.IgnoreCollision(playerCollider, projCollider);
        }

        Rigidbody2D projBody = proj.GetComponent<Rigidbody2D>();
        if(projBody != null) {
            projBody.velocity = new Vector2(this.speed.x * player.direction, this.speed.y);
        }

        return true;
    }

    void OnCollisionEnter2D(Collision2D c) {
        if(!this.surviveHittingNonPlayers || c.collider.GetComponent<Player>() != null) {
            Destroy(this.gameObject);
        }
    }
}
