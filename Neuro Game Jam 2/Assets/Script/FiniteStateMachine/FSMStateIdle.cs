using UnityEngine;
public class FSMStateIdle : FSMState
{
    public FSMStateIdle(FSM fsm) : base(fsm) { }
    public override void Enter()
    {
    }
    public override void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!=0|| Input.GetAxisRaw("Vertical") != 0)
        {
            fsm.SetState<FSMStateWalk>();
        }
    }
}