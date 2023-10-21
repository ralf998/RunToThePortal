using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : MonsterT {
    public Waiting(MonsterTSM stateMachine) : base("Waiting", stateMachine) {
        sm = (MonsterTSM)stateMachine;
    }

    public override void Enter() {
        base.Enter();
        sm.sprender.enabled= false;
        sm.LeaveWaiting();
    }
}