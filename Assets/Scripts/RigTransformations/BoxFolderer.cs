using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFolderer : MonoBehaviour
{
    [SerializeField] private Constraint _leftSide;
    [SerializeField] private Constraint _rightSide;
    [SerializeField] private Constraint _upSide;
    [SerializeField] private Constraint _downSide;
    [SerializeField] private List<Constraint> _upFoldRecoverers;
    [SerializeField] private float _delay = 1;

    public void ResetConstraintWeights()
    {
        _leftSide.Reset();
        _rightSide.Reset();
        _upSide.Reset();
        _downSide.Reset();

        foreach (var recoverer in _upFoldRecoverers)
        {
            recoverer.Reset();
        }
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

    public void FoldUpSide()
    {
        StartCoroutine(FoldUpSideRoutine(_upFoldRecoverers, _delay));
    }

    private IEnumerator FoldUpSideRoutine(List<Constraint> constraintRecoverers, float delay)
    {
        foreach (var recoverer in constraintRecoverers)
        {
            recoverer.Recover();
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator DelayedTwoSideFoldRoutine(Constraint firstConstraint, Constraint delayedConstraint, float delay)
    {
        firstConstraint.Recover();
        yield return new WaitForSeconds(delay);
        delayedConstraint.Recover();
    }
}
