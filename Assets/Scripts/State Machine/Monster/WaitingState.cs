using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : Monster {
    public Waiting(MonsterSM stateMachine) : base("Waiting", stateMachine) {
        sm = (MonsterSM)stateMachine;
    }

    public override void Enter() {
        base.Enter();
        sm.sprender.enabled= false;
        sm.GetComponent<Collider2D>().isTrigger = true;
        sm.speed = 1f;
        sm.LeaveWaiting();
    }
    
    public override void UpdateLogic() {}
    public override void UpdatePhysics() {}

    public override void Exit() {
        base.Exit();
        sm.GetComponent<Collider2D>().isTrigger = false;
    }
}