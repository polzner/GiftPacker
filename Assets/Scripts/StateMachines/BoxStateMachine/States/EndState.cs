using UnityEngine;

public class EndState : BaseState, IAvailability
{
    private Animator _characterMovingAnimator;
    private BezierMover _endMover;

    public EndState(Animator boxAnimator, IStateSwitcher stateSwitcher, Animator characterMovingAnimator, BezierMover endMover)
        : base(boxAnimator, stateSwitcher)
    {
        _characterMovingAnimator = characterMovingAnimator;
        _endMover = endMover;
    }

    public void OnEnable()
    {
        _endMover.MoveEnded += OnMoveEnded;
    }

    public void OnDisable()
    {
        _endMover.MoveEnded -= OnMoveEnded;
    }

    public override void Start()
    {
        _characterMovingAnimator.SetTrigger(CharacterMovingAnimatorParameters.Triggers.Moving);
        _endMover.RotateMove();
    }

    public override void Stop()
    {
    }

    private void OnMoveEnded()
    {
        StateSwitcher.Switch<StartState>();
        BoxTransformationAnimator.SetTrigger(BoxTransformationAnimatorParameters.Triggers.EndPacking);
    }
}
