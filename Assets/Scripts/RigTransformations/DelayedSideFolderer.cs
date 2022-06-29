using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSideFolderer : MonoBehaviour
{
    [SerializeField] private List<DelayedConstraintRecoverer> _constraintRecovereres;

    public void ResetWeight()
    {
        foreach (var recoverer in _constraintRecovereres)
        {
            recoverer.Recoverer.ResetWeight();
        }
    }

    public void Fold()
    {
        StartCoroutine(RecoverRoutine(_constraintRecovereres));
    }

    private IEnumerator RecoverRoutine(List<DelayedConstraintRecoverer> recoverers)
    {
        foreach (var recoverer in recoverers)
        {
            recoverer.Recoverer.Recover();
            yield return new WaitForSeconds(recoverer.Delay);
        }
    }


    [System.Serializable]
    private class DelayedConstraintRecoverer
    {
        [SerializeField] private ConstraintRecoverer _recoverer;
        [SerializeField] private float _delay;

        public ConstraintRecoverer Recoverer => _recoverer;
        public float Delay => _delay;
    }
}
