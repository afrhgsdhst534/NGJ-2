using UnityEngine;
public class FSMState
{
    protected readonly FSM fsm;
    protected FSMState(FSM fsm)
    {
        this.fsm = fsm;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}