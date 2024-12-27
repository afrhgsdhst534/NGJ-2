using UnityEngine;
public class FSMStateWalk : FSMState
{
    private float h;
    private float v;
    public FSMStateWalk(FSM fsm) : base(fsm) { }
    public override void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (h == 0 && v == 0)
        {
            fsm.SetState<FSMStateIdle>();
        }
    }
}