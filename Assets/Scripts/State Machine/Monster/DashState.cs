using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Dash : Monster {
    public Dash(MonsterSM stateMachine) : base("Dash", stateMachine) {
        sm = (MonsterSM)stateMachine;
    }

    public override void Enter() {
        base.Enter();
        sm.DashCicle();
        sm.speed = 0.5f;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        if (!sm.isDashing) {
            sm.rigidBody.velocity = sm.speed * (sm.player.transform.position - sm.tf.position).normalized;
            if (sm.portal.GetComponent<SpriteRenderer>().enabled == true) {
                stateMachine.ChangeState(sm.chaseState);
            }
        } else{
            sm.rigidBody.velocity = sm.dashVec;
        }
    }
}