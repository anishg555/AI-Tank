using System;
using UnityEngine;

public class SearchState : FSMBase
{
    private SmartTank ourTank;
    public SearchState(SmartTank stOurTank)
    {
        this.ourTank = stOurTank;
    }

    public override Type StateEnter()
    {
        return null;
    }

    public override Type StateExit()
    {
        return null;
    }

    public override Type StateUpdate()
    {
        if (Vector3.Distance(ourTank.transform.position, ourTank.targetTankPosition.transform.position) > 1f) return typeof(AttackState);
        else
        {
            ourTank.SearchingFor();
            return null;
        }
    }
}
