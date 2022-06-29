using UnityEngine;

public abstract class PackingBoxState : BaseState, IClickable
{
    protected Side Side;
    protected BoxModelChanger Randomizer;
    protected BoxTriggerSideAnimationPlayer SideAnimationPlayer;

    protected PackingBoxState(Animator boxAnimator,
        IStateSwitcher stateSwitcher, BoxModelChanger randomizer, BoxTriggerSideAnimationPlayer boxTriggerSideAnimationPlayer)
        : base(boxAnimator, stateSwitcher)
    {
        Randomizer = randomizer;
        SideAnimationPlayer = boxTriggerSideAnimationPlayer;
    }

    public abstract void OnLeftSideClicked();

    public abstract void OnRightSideClicked();
}
