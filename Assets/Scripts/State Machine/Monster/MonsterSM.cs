using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSM : StateMachine {
    [HideInInspector]
    public Waiting waitingState;
    [HideInInspector]
    public Chase chaseState;
    [HideInInspector]
    public Dash dashState;

    public GameObject player;
    public Transform target;
    public GameObject portal;

    public Rigidbody2D rigidBody;
    public Transform tf;
    public NavMeshAgent agent;
    public SpriteRenderer sprender;
    public float speed = 1f;

    //DashState
    public bool isDashing = false;
    public Vector2 dashVec;
    public float dashSpeed = 8f;

    private void Awake() {
        waitingState = new Waiting(this);
        chaseState = new Chase(this);
        dashState = new Dash(this);
    }

    protected override BaseState GetInitialState() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        portal = GameObject.FindGameObjectWithTag("Portal");
        tf = GetComponent<Transform>();
        return waitingState;
    }

    public void LeaveWaiting() {
        Invoke("RandState", 3f);
    }

    private void RandState() {
        this.ChangeState(chaseState);
        //this.ChangeState(dashState);

        sprender.enabled = true;
    }

    public void DashCicle() {
        if (currentState == dashState) {
            isDashing = !isDashing;
            if (isDashing) {
                dashVec =  dashSpeed * (player.transform.position - tf.position).normalized;
                Invoke("DashCicle", 0.5f);
            } else{
                Invoke("DashCicle", 3);
            }
        } else {
            isDashing = false;
        }
    }
}