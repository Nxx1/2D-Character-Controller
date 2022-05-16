using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GroundState
{
    public AttackState(CharacterControllerStateMachine characterControllerStateMachine) : base("Attack", characterControllerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(_characterControllerStateMachine.isAttack == false)
        {
            _characterControllerStateMachine.ChangeState(_characterControllerStateMachine.idleState);
        }
        
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();

        _characterControllerStateMachine.animator.SetTrigger("Attack");

    }
}
