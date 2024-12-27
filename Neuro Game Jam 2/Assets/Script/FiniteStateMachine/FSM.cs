using System.Collections.Generic;
using System;
public class FSM
{
    public FSMState curState;
    private Dictionary<Type, FSMState> states = new Dictionary<Type, FSMState>();
    public void AddState(FSMState state)
    {
        states.Add(state.GetType(), state);
    }
    public void SetState<T>() where T : FSMState
    {
        var type = typeof(T);
        if (curState!=null&&curState.GetType() == type)
        {
            return;
        }
        if(states.TryGetValue(type, out var newState))
        {
            curState?.Exit();
            curState = newState;
            curState.Enter();
        }
    }
    public void Update()
    {
        curState?.Update();
    }
}