using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Monster {
    public Chase(MonsterSM stateMachine) : base("Chase", stateMachine) {
        sm = (MonsterSM)stateMachine;
    }

    public override void Enter() {
        base.Enter();
        sm.speed = 1f;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        if (sm.rigidBody.velocity.x != 0)
        {
           
            if (sm.rigidBody.velocity.x > 0)
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
        else if (sm.rigidBody.velocity.y != 0)
        {
            if (sm.rigidBody.velocity.y > 0)
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
    }

    public override void UpdatePhysics() {
        sm.rigidBody.velocity = sm.speed * (sm.player.transform.position - sm.tf.position).normalized;
        

        if (sm.portal.GetComponent<SpriteRenderer>().enabled == true) {
            sm.rigidBody.velocity = sm.speed * (sm.rigidBody.velocity + new Vector2((sm.portal.transform.position - sm.tf.position).x, (sm.portal.transform.position - sm.tf.position).z).normalized/2).normalized;
        }
        base.UpdatePhysics();
    }
}