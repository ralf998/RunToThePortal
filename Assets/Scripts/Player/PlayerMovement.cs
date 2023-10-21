using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public float speed = 2f;

    void Start() {
        
    }

    void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidBody.velocity = (moveInput != Vector2.zero) ? speed * (moveInput).normalized : Vector2.zero;
    }
}