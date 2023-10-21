using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterT : BaseState {
    public MonsterTSM sm;
    
    public MonsterT(string name, MonsterTSM stateMachine) : base(name, stateMachine) {}

    public override void Enter() {
        base.Enter();
        sm.rigidBody.velocity = new Vector3(0,0,0);
    }

    /*public override void UpdateLogic() {
        base.UpdateLogic();
        if (sm.portal.enabled == true && sm.currentState != sm.chaseState) {
            stateMachine.ChangeState(sm.chaseState);
        }
    }*/
}