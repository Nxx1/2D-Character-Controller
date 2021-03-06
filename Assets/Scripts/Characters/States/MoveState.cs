using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : GroundState
{
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
        if (Mathf.Abs(_inputHorizontal) < Mathf.Epsilon  && _characterControllerStateMachine.Grounded)
        {
            _fsm.ChangeState(_characterControllerStateMachine.idleState);
        }

        if (Mathf.Abs(_inputHorizontal) < Mathf.Epsilon && !_characterControllerStateMachine.Grounded)
        {
            _fsm.ChangeState(_characterControllerStateMachine.jumpState);
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
        if (_characterControllerStateMachine.Grounded)
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
