using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : BaseState
{
    protected CharacterControllerStateMachine _characterControllerStateMachine;
    protected float _inputHorizontal;
    public GroundState(string name, CharacterControllerStateMachine characterControllerStateMachine) : base(name, characterControllerStateMachine)
    {
        _characterControllerStateMachine = characterControllerStateMachine;
    }

    public override void EnterState()
    {
        base.EnterState();

        _inputHorizontal = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (!_characterControllerStateMachine.Grounded)
        {
            _fsm.ChangeState(_characterControllerStateMachine.jumpState);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterControllerStateMachine.Grounded)
        {
            _characterControllerStateMachine.ChangeState(_characterControllerStateMachine.jumpState);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) && _characterControllerStateMachine.Grounded)
        {
            _characterControllerStateMachine.isAttack = true;
            _characterControllerStateMachine.ChangeState(_characterControllerStateMachine.attackState);
        }
        
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();

        _characterControllerStateMachine.animator.SetBool("Ground", _characterControllerStateMachine.Grounded);
    }

}
