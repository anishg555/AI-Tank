using System;

public class AttackState : FSMBase
{
    private SmartTank ourTank;
    public AttackState(SmartTank stOurTank)
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
