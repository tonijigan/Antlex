using System.Collections.Generic;

public abstract class InputState
{
    protected List<InputState> InputStates = new();
    protected bool IsWork = true;

    public void Init(List<InputState> states) => InputStates = states;

    public void StartPlay() => IsWork = true;

    public void StopPlay() => IsWork = false;
}