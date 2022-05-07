using UnityEngine;

public abstract class PackingBoxState : BaseState, IClickable
{
    protected Side Side;
    protected BoxRandomizer Randomizer;
    protected BoxTriggerSideAnimationPlayer SideAnimationPlayer;

    protected PackingBoxState(Animator boxAnimator,
        IStateSwitcher stateSwitcher, BoxRandomizer randomizer, BoxTriggerSideAnimationPlayer boxTriggerSideAnimationPlayer)
        : base(boxAnimator, stateSwitcher)
    {
        Randomizer = randomizer;
        SideAnimationPlayer = boxTriggerSideAnimationPlayer;
    }

    public abstract void OnLeftSideClicked();

    public abstract void OnRightSideClicked();
}
