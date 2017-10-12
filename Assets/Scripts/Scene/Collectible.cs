using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    public GameObject prefab = null;

    private void OnTrigger(Collider2D c) {
        Player p = c.gameObject.GetComponent<Player>();
        if(p != null && this.prefab != null) {
            bool collected = false;

            Item item = this.prefab.GetComponent<Item>();
            if(item != null && p.hand == null) {
                p.hand = item;

                collected = true;
            }

            if(collected) {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c) {
        this.OnTrigger(c);
    }

    void OnTriggerStay2D(Collider2D c) {
        this.OnTrigger(c);
    }
}
