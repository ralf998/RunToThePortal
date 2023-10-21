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
        /*if (!sm.isDashing) {
            sm.rigidBody.velocity = sm.speed * (sm.player.transform.position - sm.tf.position).normalized;
        } else{
            sm.rigidBody.velocity = sm.dashVec;
        }*/
        sm.target = sm.player.transform;
        base.UpdatePhysics();
    }
}