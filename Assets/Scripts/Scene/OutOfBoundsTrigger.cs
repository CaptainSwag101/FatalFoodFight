using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour {
    void OnTriggerExit2D(Collider2D c) {
        Player p = c.GetComponent<Player>();
        if(p != null) {
            // TODO: Respawn
        } else {
            Destroy(c.gameObject);
        }
    }
}
