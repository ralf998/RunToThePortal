using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BaseState {

    private float timeLeft; 
    public MonsterSM sm;
    
    public Monster(string name, MonsterSM stateMachine) : base(name, stateMachine) {}

    public override void Enter() {
        base.Enter();
        sm.rigidBody.velocity = new Vector3(0,0,0);
    }

    public override void UpdateLogic() {
        base.UpdateLogic();                

        if (sm.portal.GetComponent<SpriteRenderer>().enabled == true && sm.currentState != sm.chaseState) {
            stateMachine.ChangeState(sm.chaseState);
        }
        timeLeft += Time.deltaTime;
        if (timeLeft > 0.5f)
        {
            float velX = sm.rigidBody.velocity.x, velY = sm.rigidBody.velocity.y;
            if (velX > 0.2 || velX < -0.2)
            {

                if (velX > 0)
                {
                    sm.monsterMovement.SetBool("MovingLeft", false);
                    sm.monsterMovement.SetBool("MovingRight", true);
                }
                else 
                {
                    sm.monsterMovement.SetBool("MovingLeft", true);
                    sm.monsterMovement.SetBool("MovingRight", false);
                }
                sm.monsterMovement.SetBool("MovingDownwards", false);
                sm.monsterMovement.SetBool("MovingUpwards", false);
            }
            else if (velY != 0)
            {
                if (velY > 0)
                {
                    sm.monsterMovement.SetBool("MovingDownwards", false);
                    sm.monsterMovement.SetBool("MovingUpwards", true);
                }
                else
                {
                    sm.monsterMovement.SetBool("MovingDownwards", true);
                    sm.monsterMovement.SetBool("MovingUpwards", false);
                }
                sm.monsterMovement.SetBool("MovingLeft", false);
                sm.monsterMovement.SetBool("MovingRight", false);
            }
            timeLeft = 0f;
        }         
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        if (sm.isColliding == true) {
            if ((sm.collisionNormal.x < 0.5 && sm.collisionNormal.x > -0.5) && ((sm.player.gameObject.GetComponent<Transform>().position.y > sm.tf.position.y && sm.collisionNormal.y < sm.tf.position.y) || (sm.player.gameObject.GetComponent<Transform>().position.y < sm.tf.position.y && sm.collisionNormal.y > sm.tf.position.y))) {
                sm.rigidBody.velocity = sm.speed * new Vector2(sm.player.gameObject.GetComponent<Transform>().position.x - sm.tf.position.x, 0).normalized;
            } else if ((sm.collisionNormal.y < 0.2 && sm.collisionNormal.y > -0.2) && ((sm.player.gameObject.GetComponent<Transform>().position.x > sm.tf.position.x && sm.collisionNormal.x < sm.tf.position.x) || (sm.player.gameObject.GetComponent<Transform>().position.x < sm.tf.position.x && sm.collisionNormal.x > sm.tf.position.x))) {
                sm.rigidBody.velocity = sm.speed * new Vector2(0, sm.player.gameObject.GetComponent<Transform>().position.y - sm.tf.position.y).normalized;
            }
        }
    }
}