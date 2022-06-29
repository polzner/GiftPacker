using UnityEngine;

public class FillerPlaceState : BaseState, IAvailability
{
    private BoxFillerPlacer _boxFillerPlacer;
    private Toy _toy;
    private BoxModelChanger _boxRandomizer;
    private float _delay;

    private int _count = 0;

    public FillerPlaceState(Animator boxAnimator,
        IStateSwitcher stateSwitcher, BoxModelChanger boxRandomizer, Toy toy
        , float delay, BoxFillerPlacer boxFillerPlacer) : base(boxAnimator, stateSwitcher)
    {
        _toy = toy;
        _boxRandomizer = boxRandomizer;
        _delay = delay;
        _boxFillerPlacer = boxFillerPlacer;
    }

    private BoxFillerPlacer.ColorMode GetRandomColorMode()
    {
        if (_count == 1)
        {
            _count++;
            return BoxFillerPlacer.ColorMode.Random;
        }

        _count++;
        return BoxFillerPlacer.ColorMode.Standart;
    }

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
        _boxFillerPlacer.EnableFiller(GetRandomColorMode());
        BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.PlaceFiller);
    }

    public override void Stop()
    {
        _boxFillerPlacer.ResetFiller();
        _toy.MeshChanger.DisableMesh();
    }

    private void OnToyPlaced()
    {
        _boxRandomizer.CurrentBox.BoxFolderer.FoldUpSide();
        StateSwitcher.Switch<PackedBoxState>(_delay);
    }
}
