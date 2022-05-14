using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : BaseState
{
    protected CharacterControllerStateMachine _characterControllerStateMachine;
    protected bool grounded;
    public GroundState(string name, CharacterControllerStateMachine characterControllerStateMachine) : base(name, characterControllerStateMachine)
    {
        _characterControllerStateMachine = characterControllerStateMachine;
    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            _characterControllerStateMachine.ChangeState(_characterControllerStateMachine.jumpState);
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

        _characterControllerStateMachine.animator.SetBool("Ground", grounded);
    }

}
