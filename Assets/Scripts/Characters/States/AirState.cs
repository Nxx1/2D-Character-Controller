using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : BaseState
{
    protected CharacterControllerStateMachine _characterControllerStateMachine;
    protected float _inputHorizontal;
    public AirState(string name, CharacterControllerStateMachine characterControllerStateMachine) : base(name, characterControllerStateMachine)
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

        if (_characterControllerStateMachine.Grounded) {
            _fsm.ChangeState(_characterControllerStateMachine.idleState);
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
