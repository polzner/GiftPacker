using System.Collections;
using UnityEngine;

public class DownSideFolderer : MonoBehaviour
{
    [SerializeField] private ConstraintRecoverer _leftSide;
    [SerializeField] private ConstraintRecoverer _rightSide;
    [SerializeField] private ConstraintRecoverer _upSide;
    [SerializeField] private ConstraintRecoverer _downSide;
    [SerializeField] private float _delay;

    public void ResetWeights()
    {
        _leftSide.ResetWeight();
        _rightSide.ResetWeight();
        _upSide.ResetWeight();
        _downSide.ResetWeight();
    }

    public void FoldDownSide(Side side)
    {
        switch (side)
        {
            case Side.Left:
                StartCoroutine(DelayedTwoSideFoldRoutine(_leftSide, _rightSide, _delay));
                break;
            case Side.Right:
                StartCoroutine(DelayedTwoSideFoldRoutine(_rightSide, _leftSide, _delay));
                break;
            case Side.Up:
                StartCoroutine(DelayedTwoSideFoldRoutine(_upSide, _downSide, _delay));
                break;
            case Side.Down:
                StartCoroutine(DelayedTwoSideFoldRoutine(_downSide, _upSide, _delay));
                break;
        }
    }

    private IEnumerator DelayedTwoSideFoldRoutine(ConstraintRecoverer firstConstraint, ConstraintRecoverer delayedConstraint, float delay)
    {
        firstConstraint.Recover();
        yield return new WaitForSeconds(delay);
        delayedConstraint.Recover();
    }
}
