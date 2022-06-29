using UnityEngine;

public class StartPackingBoxState : PackingBoxState
{
    private Animator _characterMotionAnimator;
    private RigRecoverer _handRigRecoverer;

    public StartPackingBoxState(Animator boxAnimator, IStateSwitcher stateSwitcher,
        BoxModelChanger boxRandomizer, BoxTriggerSideAnimationPlayer boxTriggerSideAnimationPlayer,
        Animator characterMotionAnimator, RigRecoverer handRigRecoverer) : base(boxAnimator, stateSwitcher, boxRandomizer, boxTriggerSideAnimationPlayer)
    {
        _characterMotionAnimator = characterMotionAnimator;
        _handRigRecoverer = handRigRecoverer;
    }

    private Side GetRandomLeftRightSide() => (Side)Random.Range(0, 2);

    public override void OnLeftSideClicked()
    {
        if (Side == Side.Left)
        {
            Randomizer.CurrentBox.BoxFolderer.FoldDownSide(Side);
            StateSwitcher.Switch<EndPackingBoxState>();
        }
    }

    public override void OnRightSideClicked()
    {
        if (Side == Side.Right)
        {
            Randomizer.CurrentBox.BoxFolderer.FoldDownSide(Side);
            StateSwitcher.Switch<EndPackingBoxState>();
        }
    }

    public override void Start()
    {
        _characterMotionAnimator.SetTrigger(CharacterMovingAnimatorParameters.Triggers.Waiting);
        BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.PlaceOnSurface);
        Randomizer.CurrentBox.Mesh.enabled = true;
        Side = GetRandomLeftRightSide();
        SideAnimationPlayer.Play(Side);
        _handRigRecoverer.Recover(0);
    }

    public override void Stop()
    {
        SideAnimationPlayer.Stop();
    }
}
