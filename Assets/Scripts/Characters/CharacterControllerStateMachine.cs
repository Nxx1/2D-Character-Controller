using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStateMachine : FSM
{
    private IdleState _idleState;
    private MoveState _moveState;
    private JumpState _jumpState;

    public float characterSpeed;
    public float jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Transform _transform;

    private bool _grounded;

    private void Awake()
    {
        _idleState = new IdleState(this);
        _moveState = new MoveState(this);
        _jumpState = new JumpState(this);
        this._transform = GetComponent<Transform>();
        this._animator = GetComponent<Animator>();
        this._rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected override BaseState InitialState()
    {
        return idleState;
    }

    public IdleState idleState
    {
        get
        {
            return this._idleState;
        }
    }

    public MoveState moveState
    {
        get
        {
            return this._moveState;
        }
    }

    public JumpState jumpState
    {
        get
        {
            return this._jumpState;
        }
    }

    public Rigidbody2D rb2D
    {
        get {
            
            return _rigidbody2D;
        }
        set {
            this._rigidbody2D = rb2D;
        }
    }

    public Animator animator
    {
        get
        {
            return _animator;
        }
        set
        {
            this._animator = animator;
        }
    }

    public float CharacterSpeed
    {
        get { return characterSpeed; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }

        Debug.Log("Ground : " + _grounded);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = false;
        }
        Debug.Log("Ground : " + _grounded);
    }

    public bool Grounded
    {
        get { return _grounded; }
    }

    public Transform characterTransform
    {
        get { return _transform; }
    }

}
