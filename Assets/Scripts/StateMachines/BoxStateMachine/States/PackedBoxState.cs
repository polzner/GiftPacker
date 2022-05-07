using UnityEngine;

public class PackedBoxState : BaseState
{
    private RigRecoverer _handRigRecoverer;
    private BoxRandomizer _randomizer;
    private Animation _congragulationsAnimator;
    private ParticleSystem _starsEffect;

    public PackedBoxState(Animator boxAnimator,
        IStateSwitcher stateSwitcher, RigRecoverer handRigRecoverer, BoxRandomizer randomizer,
        Animation congragulationsAnimator, ParticleSystem starsEffect)
        : base(boxAnimator, stateSwitcher)
    {
        _handRigRecoverer = handRigRecoverer;
        _randomizer = randomizer;
        _congragulationsAnimator = congragulationsAnimator;
        _starsEffect = starsEffect;
    }

    public override void Start()
    {
        _handRigRecoverer.Recover(1);

        if (_randomizer.CurrentBox.Flipable)
            BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.Flip);
        else
            BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.WithoutFlip);

        StateSwitcher.Switch<EndState>(3f);
        _starsEffect.Play();
        _congragulationsAnimator.Play();
    }

    public override void Stop()
    {
    }
}
