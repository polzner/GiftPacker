using UnityEngine;

public abstract class BaseState
{
    protected readonly Animator BoxTransformationAnimator;
    protected readonly  IStateSwitcher StateSwitcher;

    protected BaseState(Animator boxAnimator, IStateSwitcher stateSwitcher)
    {
        BoxTransformationAnimator = boxAnimator;
        StateSwitcher = stateSwitcher;
    }

    public abstract void Start();

    public abstract void Stop();
}
