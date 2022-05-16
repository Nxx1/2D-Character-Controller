using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStateMachine : FSM
{
    private IdleState _idleState;
    private RunState _runState;
    private JumpState _jumpState;
    private GlideState _glideState;
    private AttackState _attackState;
    private JumpAttackState _jumpAttackState;

    public float characterSpeed;
    public float jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Transform _transform;

    private bool _grounded;
    private bool _isAttack;

    private void Awake()
    {
        this._idleState = new IdleState(this);
        this._runState = new RunState(this);
        this._jumpState = new JumpState(this);
        this._glideState = new GlideState(this);
        this._attackState = new AttackState(this);
        this._jumpAttackState = new JumpAttackState(this);

        this._transform = GetComponent<Transform>();
        this._animator = GetComponent<Animator>();
        this._rigidbody2D = GetComponent<Rigidbody2D>();

        this._isAttack = false;
    }

    protected override BaseState InitialState()
    {
        return idleState;
    }

    public AttackState attackState {
        get {
            return this._attackState;
        }
    }

    public GlideState glideState
    {
        get
        {
            return this._glideState;
        }
    }

    public JumpAttackState jumpAttackState
    {
        get
        {
            return this._jumpAttackState;
        }
    }

    public IdleState idleState
    {
        get
        {
            return this._idleState;
        }
    }

    public RunState runState
    {
        get
        {
            return this._runState;
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

    public bool isAttack
    {
        get
        {
            return _isAttack;
        }
        set
        {
            this._isAttack = isAttack;
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
