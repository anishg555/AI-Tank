using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, FSMBase> states;
    private FSMBase currentState;

    public FSMBase CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }

    public void SetStates(Dictionary<Type, FSMBase> tStates)
    {
        this.states = tStates;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == null) currentState = states.Values.First();
        else { 
            var nextState = CurrentState.StateUpdate(); 
            if ((nextState != null) && (nextState != currentState.GetType()))
            {
                SwitchToState(nextState);
            }
        }
    }
    void SwitchToState(Type tNextState)
    {
        CurrentState.StateExit();
        CurrentState = states[tNextState];
        CurrentState.StateEnter();
    }
}