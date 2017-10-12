using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemMonoBehaviour : MonoBehaviour, Item {
    public Sprite GetSprite() {
        SpriteRenderer r = this.GetComponent<SpriteRenderer>();
        if(r != null) {
            return r.sprite;
        }

        return null;
    }

    public abstract bool Use(Player player);
}
