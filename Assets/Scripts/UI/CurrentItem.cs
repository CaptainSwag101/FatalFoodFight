using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour {
    public GameObject player = null;
    
	void Update() {
        if(this.player != null) {
            Item hand = this.player.GetComponent<Player>().hand;

            Image image = this.GetComponent<Image>();
            image.sprite = hand != null ? hand.GetSprite() : null;
            image.enabled = image.sprite != null;
            if(image.sprite != null) {
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(image.sprite.rect.width, image.sprite.rect.height);
            }
        }
	}
}
