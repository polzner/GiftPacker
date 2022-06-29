using UnityEngine;

public class EndPackingBoxState : PackingBoxState
{
    public EndPackingBoxState(Animator boxAnimator, 
        IStateSwitcher stateSwitcher, BoxModelChanger boxRandomizer, BoxTriggerSideAnimationPlayer boxTriggerSideAnimationPlayer)
        : base(boxAnimator, stateSwitcher, boxRandomizer, boxTriggerSideAnimationPlayer)
    {
    }

    private Side GetRandomUpDownSide() => (Side)Random.Range(2, 4);

    public override void OnLeftSideClicked()
    {
        if (Side == Side.Up)
        {
            Randomizer.CurrentBox.BoxFolderer.FoldDownSide(Side);
            StateSwitcher.Switch<FillerPlaceState>();
        }
    }

    public override void OnRightSideClicked()
    {
        if (Side == Side.Down)
        {
            Randomizer.CurrentBox.BoxFolderer.FoldDownSide(Side);
            StateSwitcher.Switch<FillerPlaceState>();
        }
    }

    public override void Start()
    {
        BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.Rotate);
        Side = GetRandomUpDownSide();
        SideAnimationPlayer.Play(Side);
    }

    public override void Stop()
    {
        SideAnimationPlayer.Stop();
    }
}
