using UnityEngine;

public class PackedBoxState : BaseState
{
    private RigRecoverer _handRigRecoverer;
    private BoxModelChanger _randomizer;

    public PackedBoxState(Animator boxAnimator,
        IStateSwitcher stateSwitcher, RigRecoverer handRigRecoverer, BoxModelChanger randomizer)
        : base(boxAnimator, stateSwitcher)
    {
        _handRigRecoverer = handRigRecoverer;
        _randomizer = randomizer;
    }

    public override void Start()
    {
        _handRigRecoverer.Recover(1);

        if (_randomizer.CurrentBox.Flipable)
            BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.Flip);

        StateSwitcher.Switch<BowPlaceState>();
    }

    public override void Stop()
    {
    }
}
