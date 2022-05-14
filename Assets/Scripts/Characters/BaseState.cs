using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public string _name;
    protected FSM _fsm;

    public BaseState(string name, FSM fSM) {
        _name = name;
        _fsm = fSM;
    }

    public virtual void AwakeState() { }
    public virtual void EnterState() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void UpdateAnimation() { }
    public virtual void ExitState() { }


}
