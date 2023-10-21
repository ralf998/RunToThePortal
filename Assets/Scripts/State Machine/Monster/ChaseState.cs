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
    }
}