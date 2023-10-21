using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTSM : StateMachine {
    [HideInInspector]
    public Waiting waitingState;
    [HideInInspector]
    public Chase chaseState;

    public GameObject player;
    public GameObject portal;

    public Rigidbody2D rigidBody;
    public Transform tf;
    public SpriteRenderer sprender;
    public float speed = 1f;

    private void Awake() {
        waitingState = new Waiting(this);
        chaseState = new Chase(this);
    }

    protected override BaseState GetInitialState() {
        //player.AddRange(GameObject.FindGameObjectWithTag("Player"));
        //player.AddRange(GameObject.FindGameObjectWithTag("Portal"));
        sprender = gameObject.GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        return waitingState;
    }

    public void LeaveWaiting() {
        Invoke("RandState", 3.0f);
    }

    private void RandState() {
        this.ChangeState(chaseState);

        sprender.enabled = true;
    }
}