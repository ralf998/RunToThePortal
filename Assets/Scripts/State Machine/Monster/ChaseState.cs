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
    }

    public override void UpdatePhysics() {
        //sm.rigidBody.velocity = sm.speed * (sm.player.transform.position - sm.tf.position).normalized;
        sm.target = sm.player.transform;

        //if (sm.portal.GetComponent<SpriteRenderer>().enabled == true) {
            //sm.rigidBody.velocity = sm.speed * (sm.rigidBody.velocity + new Vector2((sm.portal.transform.position - sm.tf.position).x, (sm.portal.transform.position - sm.tf.position).z).normalized/2).normalized;
        //}
        base.UpdatePhysics();
    }
}