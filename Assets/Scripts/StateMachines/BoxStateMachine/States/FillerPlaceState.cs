using UnityEngine;

public class FillerPlaceState : BaseState, IAvailability
{
    private BoxFillerPlacer _boxFillerPlacer;
    private Toy _toy;
    private BoxRandomizer _boxRandomizer;
    private float _delay;

    public FillerPlaceState(Animator boxAnimator,
        IStateSwitcher stateSwitcher, BoxRandomizer boxRandomizer, Toy toy
        , float delay, BoxFillerPlacer boxFillerPlacer) : base(boxAnimator, stateSwitcher)
    {
        _toy = toy;
        _boxRandomizer = boxRandomizer;
        _delay = delay;
        _boxFillerPlacer = boxFillerPlacer;
    }

    private BoxFillerPlacer.ColorMode GetRandomColorMode => (BoxFillerPlacer.ColorMode)Random.Range(0, 2);

    public void OnEnable()
    {
        _toy.Placed += OnToyPlaced;
    }

    public void OnDisable()
    {
        _toy.Placed -= OnToyPlaced;
    }

    public override void Start()
    {
        _boxFillerPlacer.EnableFiller(GetRandomColorMode);
        BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.PlaceFiller);
    }

    public override void Stop()
    {
        _boxFillerPlacer.ResetFiller();
        _toy.CurrentMesh.enabled = false;
    }

    private void OnToyPlaced()
    {
        _boxRandomizer.CurrentBox.BoxFolderer.FoldUpSide();
        StateSwitcher.Switch<PackedBoxState>(_delay);
    }
}
