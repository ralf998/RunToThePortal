using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSM : StateMachine {
    [HideInInspector]
    public Waiting waitingState;
    [HideInInspector]
    public Chase chaseState;
    [HideInInspector]
    public Dash dashState;

    public GameObject player;
    public GameObject portal;

    public Rigidbody2D rigidBody;
    public Transform tf;
    public SpriteRenderer sprender;
    public float speed = 1f;

    //DashState
    public bool isDashing = false;
    public Vector2 dashVec;
    public float dashSpeed = 8f;

    //Collision
    public Vector2 collisionNormal;
    public bool isColliding = false;

    public Animator monsterMovement;

    private void Awake() {
        waitingState = new Waiting(this);
        chaseState = new Chase(this);
        dashState = new Dash(this);
        monsterMovement = GetComponent<Animator>();
    }

    protected override BaseState GetInitialState() {
        player = GameObject.FindGameObjectWithTag("Player");
        portal = GameObject.FindGameObjectWithTag("Portal");
        sprender = gameObject.GetComponent<SpriteRenderer>();
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

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if (!collisionInfo.collider.CompareTag("Player")) {
            Vector2 contactNormal = new Vector2(0,0);
            foreach (ContactPoint2D contact in collisionInfo.contacts) {
                contactNormal += contact.normal;
            }
            collisionNormal = contactNormal.normalized;
            isColliding = true;
        }
    }

    void OnCollisionStay2D(Collision2D collisionInfo) {
        if (!collisionInfo.collider.CompareTag("Player")) {
            Vector2 contactNormal = new Vector2(0,0);
            foreach (ContactPoint2D contact in collisionInfo.contacts) {
                contactNormal += contact.normal;
            }
            collisionNormal = contactNormal.normalized;
            isColliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo) {
        isColliding = false;
    }
}