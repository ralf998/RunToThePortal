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
        sm.speed = 1f;
        sm.LeaveWaiting();
    }
}