using UnityEngine;

public class BowPlaceState : BaseState, IAvailability
{
    private ParticleSystem _starEffect;
    private BowPlacer _bowPlacer;
    private BoxModelChanger _boxRandomizer;
    private Animation _congragulationsAnimation;

    public BowPlaceState(Animator boxAnimator, IStateSwitcher stateSwitcher, ParticleSystem starEffect, BowPlacer bowPlacer, BoxModelChanger boxRandomizer, Animation congragulationsAnimation) : base(boxAnimator, stateSwitcher)
    {
        _starEffect = starEffect;
        _bowPlacer = bowPlacer;
        _boxRandomizer = boxRandomizer;
        _congragulationsAnimation = congragulationsAnimation;
    }

    public void OnEnable()
    {
        _bowPlacer.BowPlaced += OnBowPlaced;
    }

    public void OnDisable()
    {
        _bowPlacer.BowPlaced -= OnBowPlaced;
    }

    public override void Start()
    {
        _bowPlacer.Place(_boxRandomizer.CurrentBox.BowPositioin);
    }

    public override void Stop()
    {
    }

    private void OnBowPlaced()
    {
        _starEffect.Play();
        BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.PlaceOnHands);
        _congragulationsAnimation.Play();
        StateSwitcher.Switch<EndState>(2f);
    }
}
