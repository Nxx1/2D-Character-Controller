using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundState
{
    public IdleState(CharacterControllerStateMachine characterControllerStateMachine) : base("Idle", characterControllerStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _inputHorizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_inputHorizontal) > Mathf.Epsilon && _characterControllerStateMachine.Grounded)
        {
            _fsm.ChangeState(_characterControllerStateMachine.runState);
        }
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();
        _characterControllerStateMachine.animator.SetBool("Run", false);
    }
}
