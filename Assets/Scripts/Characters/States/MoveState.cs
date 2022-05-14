using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : GroundState
{
    
    private float _inputHorizontal;
    public MoveState(CharacterControllerStateMachine characterControllerStateMachine) : base("Move", characterControllerStateMachine)
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

        if (Mathf.Abs(_inputHorizontal) < Mathf.Epsilon && grounded)
        {
            _fsm.ChangeState(_characterControllerStateMachine.idleState);
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Vector2 vt2 = _characterControllerStateMachine.rb2D.velocity;
        vt2.x = _inputHorizontal * _characterControllerStateMachine.CharacterSpeed;
        _characterControllerStateMachine.rb2D.velocity = vt2;
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();
        if (grounded)
        {
            _characterControllerStateMachine.animator.SetBool("Run", true);
        } else {
            _characterControllerStateMachine.animator.SetBool("Run", false);
        }

        //Flip Character
        if (_inputHorizontal > 0.01f)
        {
            _characterControllerStateMachine.transform.localScale = Vector3.one;
        }
        else if (_inputHorizontal < -0.01f)
        {
            _characterControllerStateMachine.transform.localScale = new Vector3(-1, 1, 1);
        }

    }


}
