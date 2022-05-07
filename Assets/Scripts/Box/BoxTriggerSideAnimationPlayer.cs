using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerSideAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _boxAnimator;

    public void Play(Side side)
    {
        switch (side)
        {
            case Side.Left:
                _boxAnimator.SetTrigger(BoxTriggerSideAnimatorParameters.Triggers.Left);
                break;
            case Side.Right:
                _boxAnimator.SetTrigger(BoxTriggerSideAnimatorParameters.Triggers.Right);
                break;
            case Side.Up:
                _boxAnimator.SetTrigger(BoxTriggerSideAnimatorParameters.Triggers.Up);
                break;
            case Side.Down:
                _boxAnimator.SetTrigger(BoxTriggerSideAnimatorParameters.Triggers.Down);
                break;
        }
    }

    public void Stop()
    {
        _boxAnimator.SetTrigger(BoxTriggerSideAnimatorParameters.Triggers.Packed);
    }
}
