using System;

public class RetreatState : FSMBase
{
    private SmartTank ourTank;
    public RetreatState(SmartTank stOurTank)
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
        return null;
    }
}
