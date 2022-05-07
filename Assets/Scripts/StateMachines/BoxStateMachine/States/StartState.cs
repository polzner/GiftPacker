using UnityEngine;

public class StartState : BaseState, IAvailability
{
    private PackingReseter _reseter;
    private BezierMover _startMover;

    public StartState(Animator boxAnimator, IStateSwitcher stateSwitcher, PackingReseter reseter,
        BezierMover startMover) : base(boxAnimator, stateSwitcher)
    {
        _reseter = reseter;
        _startMover = startMover;
    }

    public void OnEnable()
    {
        _startMover.MoveEnded += OnMoveEnd;
    }

    public void OnDisable()
    {
        _startMover.MoveEnded -= OnMoveEnd;
    }

    public override void Start()
    {
        _reseter.ResetParameters();
        _startMover.Move();
    }

    public override void Stop()
    {
    }

    private void OnMoveEnd()
    {
        StateSwitcher.Switch<StartPackingBoxState>();
    }
}
