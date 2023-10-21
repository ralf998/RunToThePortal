using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTSM : StateMachine {
    [HideInInspector]
    public Chase chaseState;

    public GameObject player;

    public Rigidbody2D rigidBody;
    public Transform tf;
    public float speed = 1f;

    private void Awake() {
        chaseState = new Chase(this);
    }

    protected override BaseState GetInitialState() {
        //player.AddRange(GameObject.FindGameObjectWithTag("Player"));
        tf = GetComponent<Transform>();
        return chaseState;
    }
}