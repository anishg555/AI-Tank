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
        if (ourTank.targetTank == null)
        {
            ourTank.SearchingFor();
            return null;
        }
        else if (ourTank.targetTankDistance < 20f && ourTank.targetTankDistance != -1f) return typeof(AttackState);
        else return null;
    }
}
