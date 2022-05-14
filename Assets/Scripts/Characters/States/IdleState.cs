using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundState
{
    private float _inputHorizontal;
    public IdleState(CharacterControllerStateMachine characterControllerStateMachine) : base("Idle", characterControllerStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
        _inputHorizontal = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _inputHorizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_inputHorizontal) > Mathf.Epsilon)
        {
           _fsm.ChangeState(_characterControllerStateMachine.moveState);
        }

    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();
        _characterControllerStateMachine.animator.SetBool("Run", _inputHorizontal != 0);
    }
}
