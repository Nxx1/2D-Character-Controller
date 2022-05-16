using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : AirState
{

    private float _currentForce;
    public JumpState(CharacterControllerStateMachine characterControllerStateMachine) : base("Jump", characterControllerStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        if (_characterControllerStateMachine.Grounded) {
            Vector2 vt2 = _characterControllerStateMachine.rb2D.velocity;
            vt2.y = _characterControllerStateMachine.jumpForce;
            this._currentForce = vt2.y;
            _characterControllerStateMachine.rb2D.velocity = vt2;
            Debug.Log(this._currentForce);
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _inputHorizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_inputHorizontal) > Mathf.Epsilon && !_characterControllerStateMachine.Grounded)
        {
           _fsm.ChangeState(_characterControllerStateMachine.glideState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void UpdateAnimation()
    {
        base.UpdateAnimation();
        if (_currentForce < _characterControllerStateMachine.rb2D.position.y) {
            _characterControllerStateMachine.animator.SetBool("Glide", true);
        }
        _characterControllerStateMachine.animator.SetBool("Ground", _characterControllerStateMachine.Grounded);

    }
}
