using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : GroundState
{
    public JumpState(CharacterControllerStateMachine characterControllerStateMachine) : base("Jump", characterControllerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        Vector2 vt2 = _characterControllerStateMachine.rb2D.velocity;
        vt2.y = _characterControllerStateMachine.jumpForce;
        _characterControllerStateMachine.rb2D.velocity = vt2;

        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (grounded)
        {
            _characterControllerStateMachine.ChangeState(_characterControllerStateMachine.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        grounded = _characterControllerStateMachine.Grounded;
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();
        _characterControllerStateMachine.animator.SetTrigger("Jump");
    }
}
