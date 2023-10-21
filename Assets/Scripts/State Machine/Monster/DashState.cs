using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Dash : Monster {
    public Dash(MonsterSM stateMachine) : base("Dash", stateMachine) {
        sm = (MonsterSM)stateMachine;
    }

    bool isDashing = false;
    Vector2 dashVec;
    float dashSpeed = 5f;

    public override void Enter() {
        base.Enter();
        DashCicle();
        sm.speed = 0.5f;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        if (!isDashing) {
            sm.rigidBody.velocity = sm.speed * (sm.player.transform.position - sm.tf.position).normalized;
        } else{
            sm.rigidBody.velocity = dashVec;
        }
    }

    public async void DashCicle() {
        if (!isDashing) {
            await Task.Delay(5000);
            dashVec =  dashSpeed * (sm.player.transform.position - sm.tf.position).normalized;
            DashCicle();
        } else{
            await Task.Delay(1000);
            DashCicle();
        }
    }
}