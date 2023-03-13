using System;

public abstract class FSMBase
{
    public abstract Type StateUpdate();
    public abstract Type StateEnter();
    public abstract Type StateExit();
}
