using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackState : GroundState
{
    public JumpAttackState(CharacterControllerStateMachine characterControllerStateMachine) : base("Jump Attack", characterControllerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_characterControllerStateMachine.isAttack == false)
        {
            _characterControllerStateMachine.ChangeState(_characterControllerStateMachine.jumpState);
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();

        _characterControllerStateMachine.animator.SetTrigger("Jump Attack");

    }
}
