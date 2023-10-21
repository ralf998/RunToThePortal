using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    void Start() {
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update() {}

    void Activate() {
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (this.GetComponent<SpriteRenderer>().enabled && collision.CompareTag("Player")) {
            //TODO: next scene
        }
    }
}
