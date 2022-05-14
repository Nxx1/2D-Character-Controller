using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{

    BaseState _baseState;

    // Start is called before the first frame update
    void Start()
    {
        _baseState = InitialState();
        if (_baseState != null)
        {
            _baseState.EnterState();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_baseState != null) {
            _baseState.UpdateLogic();

            _baseState.UpdateAnimation();
        }
    }

    private void LateUpdate()
    {
        if (_baseState != null) {
            _baseState.UpdatePhysics();
        }
    }

    public void ChangeState(BaseState baseState) {
        _baseState.ExitState();

        _baseState = baseState;
        _baseState.EnterState();

    }

    private void OnGUI()
    {
        string content = _baseState != null ? _baseState._name : "(no current state)";
        GUILayout.Label($"<color='white'><size='40'>{content}</size></color>");

    }

    protected virtual BaseState InitialState() {
        return null;
    }
}
