using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    private GameController gameController;

    void Start() {
        gameController = GameController.Instance;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update() {}

    public void Activate() {
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (this.GetComponent<SpriteRenderer>().enabled && collision.CompareTag("Player")) {
            gameController.returnMenu();
        }
    }
}
