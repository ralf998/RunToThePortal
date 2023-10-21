using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonsterT {
    public Chase(MonsterTSM stateMachine) : base("Chase", stateMachine) {
        sm = (MonsterTSM)stateMachine;
    }

    public override void Enter() {
        base.Enter();
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        sm.rigidBody.velocity = sm.speed * (sm.player.transform.position - sm.tf.position).normalized;

        if (sm.portal != null/*sm.portal.enabled == true*/) {
            sm.rigidBody.velocity = sm.speed * (sm.rigidBody.velocity + new Vector2((sm.portal.transform.position - sm.tf.position).x, (sm.portal.transform.position - sm.tf.position).z).normalized/3).normalized;
        }
    }
}